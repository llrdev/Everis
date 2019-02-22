using Teste.Business.Base;
using Teste.Business.Dto;

namespace Teste.Business.Contract
{
    public interface IWords
    {
        BaseResponse<int> TransformWord(WordDTO wordsDTO);
    }
}
