using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace UnityStandardAssets._2D
{
    public class Camera2D : MonoBehaviour
    {
        public Transform target;  // Đối tượng mà camera sẽ bám theo (thường là nhân vật chính).
        public float damping = 1;  // Độ mượt khi di chuyển (càng cao thì càng chậm).
        public float lookAheadFactor = 3;  // Khoảng cách camera "nhìn trước" khi nhân vật di chuyển.
        public float lookAheadReturnSpeed = 0.5f;  // Tốc độ quay lại vị trí trung tâm khi nhân vật dừng.
        public float lookAheadMoveThreshold = 0.1f;  // Ngưỡng chuyển động nhỏ nhất để kích hoạt "nhìn trước".

        private float m_OffsetZ;  // Khoảng cách Z giữa camera và target.
        private Vector3 m_LastTargetPosition;  // Lưu vị trí cũ của target.
        private Vector3 m_CurrentVelocity;  // Tốc độ hiện tại của camera (dùng cho SmoothDamp).
        private Vector3 m_LookAheadPos;  // Vị trí "nhìn trước" mà camera sẽ hướng tới.

        // Use this for initialization
        private void Start()
        {
            m_LastTargetPosition = target.position;  // Lưu lại vị trí ban đầu của target.
            m_OffsetZ = (transform.position - target.position).z;  // Tính khoảng cách Z ban đầu giữa camera và target.
            transform.parent = null;  // Tách camera khỏi parent (nếu có) để di chuyển độc lập.
        }

        // Update is called once per frame
        private void Update()
        {
            float xMoveDelta = (target.position - m_LastTargetPosition).x;  // Tính khoảng cách di chuyển của target trên trục X.

            bool updateLookAheadTarget = Mathf.Abs(xMoveDelta) > lookAheadMoveThreshold;  // Kiểm tra xem có di chuyển đủ xa để camera "nhìn trước" không.

            if (updateLookAheadTarget)
            {
                m_LookAheadPos = lookAheadFactor * Vector3.right * Mathf.Sign(xMoveDelta);  // Nếu di chuyển đủ, tính toán vị trí "nhìn trước" theo hướng di chuyển.
            }
            else
            {
                m_LookAheadPos = Vector3.MoveTowards(m_LookAheadPos, Vector3.zero, Time.deltaTime * lookAheadReturnSpeed);
                // Nếu không, từ từ quay lại vị trí gốc (camera trở về trung tâm).
            }

            Vector3 aheadTargetPos = target.position + m_LookAheadPos + Vector3.forward * m_OffsetZ;
            // Tính vị trí mới mà camera sẽ di chuyển tới (target + nhìn trước + offset Z).

            Vector3 newPos = Vector3.SmoothDamp(transform.position, aheadTargetPos, ref m_CurrentVelocity, damping);
            // Di chuyển mượt mà từ vị trí hiện tại tới vị trí mới.

            transform.position = newPos;  // Cập nhật vị trí mới cho camera.

            m_LastTargetPosition = target.position;  // Cập nhật lại vị trí target để lần sau tính tiếp.
        }

    }
}

