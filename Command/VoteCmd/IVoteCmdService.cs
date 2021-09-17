using NetCoreReactJS.Models;

namespace NetCoreReactJS.Command.VoteCmd
{
    public interface IVoteCmdService
    {
        int Add(VoteItem voteItem);
        int SubmitVote(int voteItemId, string email);
       
    }
}
