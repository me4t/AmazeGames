using System;
using CodeBase.Logic;
using UnityEngine;

namespace CodeBase.Hero
{
    public class HeroAnimator : MonoBehaviour, IAnimationStateReader
    {
        [SerializeField] private CharacterController _characterController;
        [SerializeField] private Animator _animator;

        private static readonly int MoveHash = Animator.StringToHash("Walking");

        private readonly int _idleStateHash = Animator.StringToHash("Idle");
        private readonly int _walkingStateHash = Animator.StringToHash("Run");

        public event Action<AnimatorState> StateEntered;
        public event Action<AnimatorState> StateExited;

        public AnimatorState State { get; private set; }

        private void Update()
        {
            _animator.SetFloat(MoveHash, _characterController.velocity.magnitude, 0.1f, Time.deltaTime);
        }


        public void EnteredState(int stateHash)
        {
            State = StateFor(stateHash);
            StateEntered?.Invoke(State);
        }

        public void ExitedState(int stateHash)
        {
            StateExited?.Invoke(StateFor(stateHash));
        }

        private AnimatorState StateFor(int stateHash)
        {
            AnimatorState state;
            if (stateHash == _idleStateHash)
            {
                state = AnimatorState.Idle;
            }
            else if (stateHash == _walkingStateHash)
            {
                state = AnimatorState.Walking;
            }
            else
            {
                state = AnimatorState.Unknown;
            }

            return state;
        }
    }
}