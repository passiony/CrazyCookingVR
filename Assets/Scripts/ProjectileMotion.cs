using System;
using UnityEngine;

public class ProjectileMotion : MonoBehaviour
{
    private Transform m_Target; // 目标点
    private float gravity = 9.8f; // 重力

    public void ShootToTarget(Transform target)
    {
        m_Target = target;
        LaunchProjectile();
    }

    void LaunchProjectile()
    {
        // 计算初始速度向量
        Vector3 projectileVelocity = CalculateProjectileVelocity();

        // 应用速度
        gameObject.GetComponent<Rigidbody>().velocity = projectileVelocity;
    }

    Vector3 CalculateProjectileVelocity()
    {
        // 计算初始速度向量
        float projectileTime = CalculateTimeToTarget();
        Vector3 toTarget = m_Target.position - transform.position;
        Vector3 verticalVelocity = Vector3.up * gravity * projectileTime / 2.0f;
        Vector3 horizontalVelocity = toTarget / projectileTime;

        return horizontalVelocity + verticalVelocity;
    }

    float CalculateTimeToTarget()
    {
        // 计算抛射到目标所需的时间
        float targetDistance = Vector3.Distance(transform.position, m_Target.position);
        float time = Mathf.Sqrt(2 * targetDistance / gravity);
        return time;
    }
}