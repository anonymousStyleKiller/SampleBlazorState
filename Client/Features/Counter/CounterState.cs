using BlazorState;
using MediatR;

namespace Sample.Client.Features.Counter;

public class CounterState : State<CounterState>
{
    public int Count { get; set; }
    public override void Initialize()=>Count = 3;
    public class IncrementCountAction  : IAction
    {
        public int Amount { get; set; }
    }
    
    public class IncrementCountHandler : ActionHandler<IncrementCountAction>
    {
        public IncrementCountHandler(IStore aStore) : base(aStore) { }

        CounterState CounterState => Store.GetState<CounterState>();

        public override Task<Unit> Handle(IncrementCountAction aIncrementCountAction, CancellationToken aCancellationToken)
        {
            CounterState.Count = CounterState.Count + aIncrementCountAction.Amount;
            return Unit.Task;
        }
    }
}