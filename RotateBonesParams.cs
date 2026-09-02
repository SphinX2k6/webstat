using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x020030BF RID: 12479
[NullableContext(1)]
[Nullable(0)]
public class RotateBonesParams
{
	// Token: 0x170022A0 RID: 8864
	// (get) Token: 0x06019B76 RID: 105334 RVA: 0x0077BCB0 File Offset: 0x00779EB0
	// (set) Token: 0x06019B77 RID: 105335 RVA: 0x0077BCB8 File Offset: 0x00779EB8
	public long Handle { get; private set; }

	// Token: 0x06019B78 RID: 105336 RVA: 0x0077BCC4 File Offset: 0x00779EC4
	public RotateBonesParams(long handle, TArray<string> bones)
	{
		this.Handle = handle;
		int num = bones.Num();
		for (int i = 0; i < num; i++)
		{
			string text = bones.Get(i);
			if (!string.IsNullOrEmpty(text))
			{
				this.RotateBoneItemMap[text] = new RotateBoneItem();
			}
		}
	}

	// Token: 0x06019B79 RID: 105337 RVA: 0x0077BD28 File Offset: 0x00779F28
	public void Set(float timeLength, float targetAlpha, Dictionary<string, float> currentAlphaMap)
	{
		this.CurrentTime = 0f;
		this.TimeLength = timeLength;
		foreach (KeyValuePair<string, RotateBoneItem> keyValuePair in this.RotateBoneItemMap)
		{
			float startAlpha = 0f;
			currentAlphaMap.TryGetValue(keyValuePair.Key, out startAlpha);
			keyValuePair.Value.Set(startAlpha, targetAlpha, null);
		}
		this.GoingToEnd = (targetAlpha <= 0f);
	}

	// Token: 0x06019B7A RID: 105338 RVA: 0x0077BDBC File Offset: 0x00779FBC
	public bool IsEnd()
	{
		return this.RotateBoneItemMap.Count == 0 || (this.GoingToEnd && this.CurrentTime >= this.TimeLength);
	}

	// Token: 0x06019B7B RID: 105339 RVA: 0x0077BDE8 File Offset: 0x00779FE8
	public void GetAndUpdate(float deltaTime, Dictionary<string, float> outAlphaMap)
	{
		this.CurrentTime += deltaTime;
		List<string> list = new List<string>();
		foreach (KeyValuePair<string, RotateBoneItem> keyValuePair in this.RotateBoneItemMap)
		{
			if (outAlphaMap.ContainsKey(keyValuePair.Key))
			{
				list.Add(keyValuePair.Key);
			}
			else
			{
				outAlphaMap[keyValuePair.Key] = keyValuePair.Value.GetBoneAlpha(this.CurrentTime / this.TimeLength);
			}
		}
		foreach (string key in list)
		{
			this.RotateBoneItemMap.Remove(key);
		}
	}

	// Token: 0x0400CCD9 RID: 52441
	private readonly Dictionary<string, RotateBoneItem> RotateBoneItemMap = new Dictionary<string, RotateBoneItem>();

	// Token: 0x0400CCDA RID: 52442
	private float CurrentTime;

	// Token: 0x0400CCDB RID: 52443
	private float TimeLength = 1f;

	// Token: 0x0400CCDC RID: 52444
	public bool GoingToEnd;
}
