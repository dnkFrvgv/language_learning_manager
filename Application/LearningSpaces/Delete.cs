using Application.Core;
using MediatR;
using Persistence;

namespace Application.LearningSpaces
{
  public class Delete
    {
    public class Command : IRequest<ResponseHandler<Unit>>
    {
      public Guid Id { get; set; }
    }

    public class Handler : IRequestHandler<Command, ResponseHandler<Unit>>
    {
      private readonly DataContext _context;
      public Handler(DataContext context)
      {
        _context = context;
      }
      public async Task<ResponseHandler<Unit>> Handle(Command request, CancellationToken cancellationToken)
      {
        var spaces = await _context.LearningSpaces.FindAsync(request.Id);

        if(spaces == null){
          return ResponseHandler<Unit>.NotFoundResponse("Learning Space");
        }

        _context.Remove(spaces);
        await _context.SaveChangesAsync();
        
        return ResponseHandler<Unit>.SuccessResponse(Unit.Value);
      }
    }
  }
}