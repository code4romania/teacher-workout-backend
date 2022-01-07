using System.Threading.Tasks;
using GraphQL.Language.AST;
using GraphQL.Validation;

namespace TeacherWorkout.Api.GraphQL.ValidationRules
{
    public class RequiresAuthValidationRule : IValidationRule
    {
        public Task<INodeVisitor> ValidateAsync(ValidationContext context)
        {
            var userContext = context.UserContext as GraphQlUserContext;
            var authenticated = userContext?.User?.Identity?.IsAuthenticated ?? false;

            return Task.FromResult((INodeVisitor)new NodeVisitors(
                new MatchingNodeVisitor<Operation>((operation, context) =>
                {
                    if (operation.Name == "IntrospectionQuery")
                    {
                        return;
                    }

                    if (!authenticated)
                    {
                        context.ReportError(
                            new ValidationError(
                                    context.Document.OriginalQuery,
                                    "6.1.1", // the rule number of this validation error corresponding to the paragraph number from the official specification
                                    $"Authentication is required to access {operation.Name}.")
                                { Code = "auth-required" });
                    }
                })));
        }
    }
}
