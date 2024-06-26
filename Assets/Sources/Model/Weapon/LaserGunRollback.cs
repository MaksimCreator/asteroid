﻿using UnityEngine;

namespace Asteroids.Model
{
    public class LaserGunRollback
    {
        public readonly float Cooldown;

        private readonly ILaserGun _laser;

        public float AccumulatedTime { get; private set; }

        public LaserGunRollback(ILaserGun laser, float cooldown)
        {
            _laser = laser;
            Cooldown = cooldown;
        }

        public void Tick(float deltaTime)
        {
            if (_laser.Bullets == _laser.MaxBullets)
                return;

            AccumulatedTime += deltaTime;

            if (AccumulatedTime >= Cooldown)
            {
                _laser.TryAddShot();
                AccumulatedTime = 0;
            }
        }
    }
}
