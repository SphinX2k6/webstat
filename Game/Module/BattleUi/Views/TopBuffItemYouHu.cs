using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x0200611E RID: 24862
	public class TopBuffItemYouHu : TopBuffItem
	{
		// Token: 0x0603ECDC RID: 257244 RVA: 0x010154B4 File Offset: 0x010136B4
		protected unsafe override void OnRegisterComponent()
		{
			int num = 1;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int index = 0;
			*span[index] = new ValueTuple<int, Type>(0, typeof(UUITexture));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603ECDD RID: 257245 RVA: 0x010154FC File Offset: 0x010136FC
		public void RefreshByTag(int tagId)
		{
			if (this.TagId == tagId)
			{
				return;
			}
			this.TagId = tagId;
			string resourceId;
			if (!TopBuffItemYouHu.Tag2IconMap.TryGetValue(tagId, out resourceId))
			{
				return;
			}
			string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(resourceId);
			this.SetIcon(resourcePath);
		}

		// Token: 0x0603ECDE RID: 257246 RVA: 0x0101553D File Offset: 0x0101373D
		[NullableContext(2)]
		public void SetIcon(string iconPath)
		{
			base.GetTexture(0).SetUIActive(false);
			if (string.IsNullOrEmpty(iconPath))
			{
				return;
			}
			this.LoadIconId = Singleton<ResourceSystem>.Instance.LoadAsync<UTexture>(iconPath, delegate([Nullable(2)] UTexture skillIconTexture, string _)
			{
				this.LoadIconId = -1;
				if (skillIconTexture == null)
				{
					return;
				}
				UUITexture texture = base.GetTexture(0);
				if (texture == null)
				{
					return;
				}
				texture.SetUIActive(true);
				texture.SetTexture(skillIconTexture);
			}, 103, "js_undefined");
		}

		// Token: 0x0603ECDF RID: 257247 RVA: 0x01015579 File Offset: 0x01013779
		protected override void OnBeforeDestroyImplement()
		{
			base.OnBeforeDestroyImplement();
			if (this.LoadIconId != -1)
			{
				Singleton<ResourceSystem>.Instance.CancelAsyncLoad(this.LoadIconId);
				this.LoadIconId = -1;
			}
		}

		// Token: 0x0603ECE1 RID: 257249 RVA: 0x010155AC File Offset: 0x010137AC
		// Note: this type is marked as 'beforefieldinit'.
		static TopBuffItemYouHu()
		{
			Dictionary<int, string> dictionary = new Dictionary<int, string>();
			int key = GameplayTagDefine.EGameplayTagId["角色.R2T1YouHuMd10011.逻辑.底奖.如意"];
			dictionary[key] = "T_IconYouhuBuff05";
			int key2 = GameplayTagDefine.EGameplayTagId["角色.R2T1YouHuMd10011.逻辑.底奖.编钟"];
			dictionary[key2] = "T_IconYouhuBuff01";
			int key3 = GameplayTagDefine.EGameplayTagId["角色.R2T1YouHuMd10011.逻辑.底奖.面具"];
			dictionary[key3] = "T_IconYouhuBuff04";
			int key4 = GameplayTagDefine.EGameplayTagId["角色.R2T1YouHuMd10011.逻辑.底奖.鼎"];
			dictionary[key4] = "T_IconYouhuBuff02";
			TopBuffItemYouHu.Tag2IconMap = dictionary;
		}

		// Token: 0x04023398 RID: 144280
		[Nullable(1)]
		[StaticVariableRuleIgnore]
		private static readonly Dictionary<int, string> Tag2IconMap;

		// Token: 0x04023399 RID: 144281
		private int TagId;

		// Token: 0x0402339A RID: 144282
		private int LoadIconId;

		// Token: 0x0200C2A7 RID: 49831
		private enum EChildType
		{
			// Token: 0x0403C035 RID: 245813
			IconTexture
		}
	}
}
