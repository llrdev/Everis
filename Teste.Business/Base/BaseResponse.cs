namespace Teste.Business.Base
{
    public class BaseResponse<T>
    {
        public Message status { get; set; }

        public BaseResponse()
        {
            status = new Message();
        }

        public T Response { get; set; }
    }
}
