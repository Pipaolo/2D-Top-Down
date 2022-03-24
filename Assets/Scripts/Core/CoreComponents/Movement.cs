using UnityEngine;

namespace Core.CoreComponents
{
    public class Movement : CoreComponent
    {
        public Rigidbody2D RB { get; private set; }
        public Camera Camera { get; set; }

        public int FacingDirection { get; private set; }
        

        public bool CanSetVelocity { get; set; }

        public Vector2 CurrentVelocity { get; private set; }

        private Vector2 workspace;

        protected override void Awake()
        {
            base.Awake();

            RB = GetComponentInParent<Rigidbody2D>();

            FacingDirection = 1;
            CanSetVelocity = true;
        
        }

        public void LogicUpdate()
        {
            CurrentVelocity = RB.velocity;
        }

        #region Set Functions

        public void SetVelocityZero()
        {
            workspace = Vector2.zero;        
            SetFinalVelocity();
        }

        public void SetRotation(float rotation)
        {
            RB.rotation = rotation;
        }

        public void SetVelocity(float velocity, Vector2 angle, int direction)
        {
            angle.Normalize();
            workspace.Set(angle.x * velocity * direction, angle.y * velocity);
            SetFinalVelocity();
        }

        public void SetVelocity(float velocity, Vector2 direction)
        {
            workspace = direction * velocity;
            SetFinalVelocity();
        }

        public void SetVelocityX(float velocity)
        {
            workspace.Set(velocity, CurrentVelocity.y);
            SetFinalVelocity();
        }

        public void SetVelocityY(float velocity)
        {
            workspace.Set(CurrentVelocity.x, velocity);
            SetFinalVelocity();
        }

        private void SetFinalVelocity()
        {
            if (CanSetVelocity)
            {
                RB.velocity = workspace;
                CurrentVelocity = workspace;
            }        
        }

    
        #endregion
        
    }
}