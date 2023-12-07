using System.ComponentModel.DataAnnotations;
using TeacherWorkout.Domain.Common;
using TeacherWorkout.Domain.FileBlobs;
using TeacherWorkout.Domain.Images;
using TeacherWorkout.Domain.Models;
using TeacherWorkout.Domain.Models.Inputs;
using TeacherWorkout.Domain.Models.Payloads;

namespace TeacherWorkout.Domain.Themes
{
    public class CreateTheme(IThemeRepository themeRepository,
        IImageRepository imageRepository,
        IFileBlobRepository fileBlobRepository) : IOperation<ThemeCreateInput, ThemeCreatePayload>
    {
        private readonly IThemeRepository _themeRepository = themeRepository;
        private readonly IImageRepository _imageRepository = imageRepository;
        private readonly IFileBlobRepository _fileBlobRepository = fileBlobRepository;

        public ThemeCreatePayload Execute(ThemeCreateInput input)
        {
            var theme = new Theme
            {
                Title = input.Title
            };

            if (!string.IsNullOrEmpty(input.FileBlobId))
            {
                var fileBlob = _fileBlobRepository.Find(input.FileBlobId) ?? throw new ValidationException("FileBlob ID not found");
                var thumbnail = new Image
                {
                    Description = fileBlob.Description,
                    FileBlob = fileBlob
                };
                theme.Thumbnail = thumbnail;
            }
            else
            {
                theme.Thumbnail = _imageRepository.Find(input.ThumbnailId) ?? throw new ValidationException("Thumbnail ID not found");
            }

            _themeRepository.Insert(theme);

            return new ThemeCreatePayload
            {
                Theme = theme
            };
        }
    }
}
