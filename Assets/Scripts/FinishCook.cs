using UnityEngine;

public class FinishCook : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MealPlate"))
        {
            var comps = other.transform.GetComponentsInChildren<BaseIngredient>();
            if (IsFinish(comps))
            {
                Debug.Log("送餐成功" + other.name);
            }
            else
            {
                Debug.Log("送餐失败" + other.name);
            }
            other.gameObject.SetActive(false);
            Destroy(other.gameObject);
        }
    }

    bool IsFinish(BaseIngredient[] childs)
    {
        foreach (var comp in childs)
        {
            if (comp is Ingredient)
            {
                return false;
            }
            if (comp is HalfIngredient half && !half.Cooked)
            {
                return false;
            }
        }

        return true;
    }
}