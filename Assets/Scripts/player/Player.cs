using System;
using UnityEngine;
using util;

namespace player {
    public abstract class Player : MonoBehaviour {
        private const string Tag = "Player";

        internal float Speed = 3;
        internal float AttackCd = 0.4f;
        internal float BulletLevel = 1;

        public GameObject nextLevel;
        public GameObject bullet;

        private float _attackingCd;

        private void Awake() {
            InitParams();
            _attackingCd = AttackCd;
        }

        private void Start() {
            Log.D(Tag, "Start: level = " + GetLevel());
            // Invoke($"Upgrade", 3f);
        }

        private void InitParams() {
            int level = GetLevel();
            Speed = Constant.TankSpeed[level - 1];
            AttackCd = Constant.AttackCd[level - 1];
            BulletLevel = level;
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

        // 升级
        private void Upgrade() {
            var newLevel = Utils.GetSafeLevel(GetLevel() + 1);
            if (newLevel <= GetLevel()) return;
            Instantiate(nextLevel, transform.position, transform.rotation);
            Destroy(gameObject);
        }

        protected abstract int GetLevel();
    }
}