using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Utils
{
	// Token: 0x020046FF RID: 18175
	public class TsAnimNotifyUtils
	{
		// Token: 0x0602F416 RID: 193558 RVA: 0x00B34E24 File Offset: 0x00B33024
		[NullableContext(1)]
		public static bool CheckTags(bool needAnyTag, TMap<FGameplayTag, bool> playNeedTags, Func<int, bool> tagCheckFunc)
		{
			int num = playNeedTags.Num();
			if (needAnyTag)
			{
				for (int i = 0; i < num; i++)
				{
					FGameplayTag key = playNeedTags.GetKey(i);
					bool flag = playNeedTags.Get(key);
					if (tagCheckFunc(key.TagId()) == flag)
					{
						return true;
					}
				}
				return false;
			}
			for (int j = 0; j < num; j++)
			{
				FGameplayTag key2 = playNeedTags.GetKey(j);
				bool flag2 = playNeedTags.Get(key2);
				if (tagCheckFunc(key2.TagId()) != flag2)
				{
					return false;
				}
			}
			return true;
		}
	}
}
