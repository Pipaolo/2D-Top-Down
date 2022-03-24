namespace Enemy.EnemyFiniteStateMachine
{
    public class EnemyStateMachine
    {
        public EnemyState CurrentState { get; private set; }

        public void Initialize(EnemyState state)
        {
            CurrentState = state;
            CurrentState.Enter();
        }

        public void UpdateState(EnemyState state)
        {
            CurrentState.Exit();
            CurrentState = state;
            CurrentState.Enter();
        }
    }
}