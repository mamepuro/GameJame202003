using System;
using System.Collections.Generic;
using System.Text;
using Altseed2;

namespace GameJam
{
    class CollidableObject:SpriteNode
    {
        public static HashSet<CollidableObject> collidableObjects = new HashSet<CollidableObject>();

        public RectangleCollider collider = RectangleCollider.Create();

        protected bool doSurvey;

        public CollidableObject(Vector2F position)
        {
            Position = position;
            collider.Position = position;
        }

        protected override void OnAdded()
        {
            base.OnAdded();
            collidableObjects.Add(this);
        }

        protected override void OnRemoved()
        {
            base.OnRemoved();
            collidableObjects.Remove(this);
        }

        protected override void OnUpdate()
        {
            base.OnUpdate();
            if(doSurvey)
            {
                Survey();
            }
            collider.Position = Position;
        }
        protected void Survey()
        {
            foreach(var obj in collidableObjects)
            {
                if(collider.GetIsCollidedWith(obj.collider))
                {
                    CollideWith(obj);
                }
            }
        }
        protected virtual void OnCollide(CollidableObject obj)
        {
            //継承先で決定
        }

        protected void CollideWith(CollidableObject obj)
        {
            if(obj == null)
            {
                return;
            }
            if(!obj.doSurvey)
            {
                obj.OnCollide(this);
            }
            OnCollide(obj);
        }
    }
}
