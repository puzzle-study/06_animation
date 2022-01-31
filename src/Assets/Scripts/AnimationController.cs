using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController
{
    float _time = 0.0f;
    float _inv_time_max = 1.0f;
    const float DELTA_TIME_MAX = 1.0f;

    public void Set(float max_time)
    {
        Debug.Assert(0.0f < max_time);// 負の遷移時間は不正

        _time = max_time;
        _inv_time_max = 1.0f / max_time;
    }

    // アニメーション中ならtrueを返す
    public bool Update(float delta_time)
    {
        // あまり時間が経った結果はあやしいので、更新時間の上限を導入する
        if(DELTA_TIME_MAX < delta_time) delta_time = DELTA_TIME_MAX;

        _time -= delta_time;

        // 0になったら終了
        if (_time <= 0.0f)
        {
            _time = 0.0f;// 負の数にしない
            return false;
        }

        return true;
    }

    public float GetNormalized()
    {
        return _time * _inv_time_max;
    }
}
