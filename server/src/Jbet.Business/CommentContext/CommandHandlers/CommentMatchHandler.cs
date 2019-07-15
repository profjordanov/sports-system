using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using Jbet.Business.Base;
using Jbet.Core.CommentContext.Commands;
using Jbet.Domain;
using Jbet.Domain.Entities;
using Jbet.Domain.Events.Base;
using Jbet.Domain.Repositories;
using MediatR;
using Optional;
using Optional.Async.Extensions;

namespace Jbet.Business.CommentContext.CommandHandlers
{
    public class CommentMatchHandler : BaseHandler<CommentMatch>
    {
        private readonly ICommentRepository _commentRepository;

        public CommentMatchHandler(
            IValidator<CommentMatch> validator,
            IEventBus eventBus,
            IMapper mapper,
            ICommentRepository commentRepository)
            : base(validator, eventBus, mapper)
        {
            _commentRepository = commentRepository;
        }

        public override Task<Option<Unit, Error>> Handle(CommentMatch command)
        {
            throw new System.NotImplementedException();
        }

        private Task<Option<Unit, Error>> SimilarCommentShouldNotExist(CommentMatch command) =>
            _commentRepository.GetByMatchAndUserAsync(command.MatchId, command.UserId)
                .SomeWhenAsync(comment => comment == null, Error.Conflict("Similar comment already exists."))
                .MapAsync(_ => Task.FromResult(Unit.Value));

        private Task<Option<Comment, Error>> SaveToRelationalDatabase(CommentMatch command) =>
            _commentRepository.AddAsync(
                    content: command.Content,
                    matchId: command.MatchId,
                    userId: command.UserId)
                .SomeNotNullAsync(Error.Critical("Something went wrong!"));

    }
}