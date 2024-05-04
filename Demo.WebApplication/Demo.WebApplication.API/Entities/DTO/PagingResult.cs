namespace Demo.WebApplication.API.Entities.DTO
{
    public class PagingResult
    {
        public List<Employee> Data { get; set; }

        /// <summary>
        /// Tổng số bản ghi thỏa mãn điều kiện
        /// </summary>
        public int TotalRecord { get; set; }
    }
}
