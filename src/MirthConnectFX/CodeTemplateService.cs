using MirthConnectFX.Model;
using MirthConnectFX.Utility;

namespace MirthConnectFX
{
    public class CodeTemplateService : ServiceBase, ICodeTemplateService
    {
        public CodeTemplateService(IMirthConnectRequestFactory mirthConnectRequestFactory, IMirthConnectSession session)
            : base(mirthConnectRequestFactory, session, "codetemplates")
        {
        }

        public void UpdateCodeTemplates(CodeTemplateList codeTemplates)
        {
            var request = CreateRequest().ForOperation(Operations.CodeTemplates.UpdateCodeTemplatse);
            request.AddPostData("codeTemplates", codeTemplates.ToXml());

            request.Execute();
        }
    }
}