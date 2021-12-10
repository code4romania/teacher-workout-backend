using TeacherWorkout.Domain.Common;
using TeacherWorkout.Domain.Images;
using TeacherWorkout.Domain.Models.Inputs;
using TeacherWorkout.Domain.Models.Payloads;

namespace TeacherWorkout.Domain.Themes
{
    public class UpdateTheme: IOperation<ThemeUpdateInput, ThemeUpdatePayload>
    {
        private readonly IThemeRepository _themeRepository;
        private readonly IImageRepository _imageRepository;

        public UpdateTheme(IThemeRepository themeRepository, IImageRepository imageRepository)
        {
            _themeRepository = themeRepository;
            _imageRepository = imageRepository;
        }

        public ThemeUpdatePayload Execute(ThemeUpdateInput input)
        {
            var theme = _themeRepository.Update(input);

            return new ThemeUpdatePayload
            {
                Theme = theme
            };
        }
    }
}
