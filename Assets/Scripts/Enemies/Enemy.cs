using System;
using UnityEngine;
using util;

namespace Enemies {
    public abstract class Enemy : MonoBehaviour {
        private const string Tag = "Player";

        internal float Speed = 3;
        internal float AttackCd = 0.4f;
        internal float BulletLevel = 1;

        public GameObject bullet;

        private float _attackingCd;
        private float _score;
        private int _type;

        private void Awake() {
            InitParams();
            _attackingCd = AttackCd;
        }

        private void InitParams() {
            int countDown = isRed() ? 5 : 0;
            _type = GetType();
            Speed = Constant.EnemyTankSpeed[_type - 1 - countDown];
            AttackCd = Constant.EnemyAttackCd[_type - 1 - countDown];
            BulletLevel = _type - countDown;
        }

        private void FixedUpdate() {
            var h = Input.GetAxis("Horizontal");
            var v = Input.GetAxis("Vertical");
            CheckMove(h, v);
            CheckAttackCd();
        }


        // 检测移动并旋转方向
        private void CheckMove(float h, float v) {
            Log.D(Tag, "CheckMove called with h = " + h + ", v = " + v);

            if (Math.Abs(v) > Utils.Tolerance) {
                if (v > 0f) {
                    transform.rotation = Quaternion.Euler(0, 0, 0);
                } else if (v < 0f) {
                    transform.rotation = Quaternion.Euler(0, 0, 180);
                }

                transform.Translate(v * Speed * Time.fixedDeltaTime * Vector3.up, Space.World);
            } else {
                if (h > 0f) {
                    transform.rotation = Quaternion.Euler(0, 0, -90);
                } else if (h < 0f) {
                    transform.rotation = Quaternion.Euler(0, 0, 90);
                }

                transform.Translate(h * Speed * Time.fixedDeltaTime * Vector3.right, Space.World);
            }
        }

        private void CheckAttackCd() {
            if (_attackingCd >= AttackCd) {
                if (Input.GetKey(KeyCode.Space)) {
                    GameObject bulletIns = Instantiate(bullet, transform.position, transform.rotation);
                    bulletIns.SendMessage("UpdateBulletParams", BulletLevel);
                    _attackingCd = 0f;
                }
            } else {
                _attackingCd += Time.deltaTime;
            }
        }

        protected abstract int GetType();

        protected abstract bool isRed();
    }
}