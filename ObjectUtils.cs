using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02000C1F RID: 3103
[NullableContext(1)]
[Nullable(0)]
public static class ObjectUtils
{
	// Token: 0x0600357E RID: 13694 RVA: 0x00031565 File Offset: 0x0002F765
	public static void CopyValue(object copyObj, object obj)
	{
	}

	// Token: 0x0600357F RID: 13695 RVA: 0x00031567 File Offset: 0x0002F767
	[NullableContext(2)]
	public static bool IsValid([NotNullWhen(true)] UObject obj)
	{
		return obj != null && obj.IsValid();
	}

	// Token: 0x06003580 RID: 13696 RVA: 0x00031574 File Offset: 0x0002F774
	[NullableContext(2)]
	public static bool SoftObjectPathIsValid(FSoftObjectPath objPath)
	{
		return !(objPath == null) && !FNameUtil.IsNothing(objPath.AssetPathName);
	}

	// Token: 0x06003581 RID: 13697 RVA: 0x00031590 File Offset: 0x0002F790
	public static bool SoftObjectReferenceValid<[Nullable(0)] T>(TSoftObjectPtr<T> objRef) where T : UnrealUObject
	{
		string text = objRef.ToAssetPathName();
		return text != null && text.Length > 0 && text != "None";
	}

	// Token: 0x06003582 RID: 13698 RVA: 0x000315C0 File Offset: 0x0002F7C0
	public static List<FGameplayTag> GetGameplayTags(IReadOnlyList<string> tagNames)
	{
		List<FGameplayTag> list = new List<FGameplayTag>();
		foreach (string tagName in tagNames)
		{
			FGameplayTag? gameplayTagByName = GameplayTagUtils.GetGameplayTagByName(tagName);
			if (gameplayTagByName != null)
			{
				list.Add(gameplayTagByName.Value);
			}
		}
		return list;
	}

	// Token: 0x06003583 RID: 13699 RVA: 0x00031624 File Offset: 0x0002F824
	[NullableContext(2)]
	public static T GetRandomArrayItem<T>([Nullable(1)] IList<T> array)
	{
		int count = array.Count;
		if (count > 0)
		{
			int num = 0;
			if (count > 1)
			{
				num = (int)Singleton<MathUtils>.Instance.GetRandomRange(0.0, (double)count);
				if (num == count)
				{
					num--;
				}
			}
			return array[num];
		}
		return default(T);
	}

	// Token: 0x06003584 RID: 13700 RVA: 0x00031674 File Offset: 0x0002F874
	[NullableContext(0)]
	public static T? GetRandomStructArrayItem<T>([Nullable(new byte[]
	{
		1,
		0
	})] IList<T> array) where T : struct
	{
		if (array.Count > 0)
		{
			return new T?(ObjectUtils.GetRandomArrayItem<T>(array));
		}
		return null;
	}

	// Token: 0x06003585 RID: 13701 RVA: 0x000316A0 File Offset: 0x0002F8A0
	public static IList<T> ueArrayToArray<[Nullable(2)] T>(TArray<T> array)
	{
		int num = array.Num();
		List<T> list = new List<T>();
		for (int i = 0; i < num; i++)
		{
			list.Add(array.Get(i));
		}
		return list;
	}
}
