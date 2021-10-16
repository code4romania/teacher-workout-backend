using TeacherWorkout.Domain.Common;
using TeacherWorkout.Domain.Images;
using TeacherWorkout.Domain.Models;
using TeacherWorkout.Domain.Models.Inputs;
using TeacherWorkout.Domain.Models.Payloads;

namespace TeacherWorkout.Domain.Themes
{
    public class CreateTheme : IOperation<ThemeCreateInput, ThemeCreatePayload>
    {
        private readonly IThemeRepository _themeRepository;
        private readonly IImageRepository _imageRepository;

        public CreateTheme(IThemeRepository themeRepository,
            IImageRepository imageRepository)
        {
            _themeRepository = themeRepository;
            _imageRepository = imageRepository;
        }
        
        public ThemeCreatePayload Execute(ThemeCreateInput input)
        {
            var theme = new Theme
            {
                Title = input.Title,
                Thumbnail = _imageRepository.Find(input.ThumbnailId)
            };

            _themeRepository.Insert(theme);
            
            return new ThemeCreatePayload
            {
                Theme = theme
            };
        }
    }
}