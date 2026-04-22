namespace EOkul.Application.Dtos.CourseDtos
{
    public class CreateCourseDto
    {
        public string Name { get; set; }
        public int WeeklyHours { get; set; }
        //Oluşturulan her kurs otomatik aktif olarak seçilir.
    }
}
