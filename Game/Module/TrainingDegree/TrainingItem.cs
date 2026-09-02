using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.TrainingDegree
{
	// Token: 0x02004E78 RID: 20088
	public class TrainingItem : UiPanelBase
	{
		// Token: 0x06033E7A RID: 212602 RVA: 0x00CFD5AF File Offset: 0x00CFB7AF
		[NullableContext(1)]
		public TrainingItem(UUIItem uiItem)
		{
			base.CreateThenShowByActor(uiItem.GetOwner(), null);
		}

		// Token: 0x06033E7B RID: 212603 RVA: 0x00CFD5C4 File Offset: 0x00CFB7C4
		protected unsafe override void OnRegisterComponent()
		{
			int num = 5;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUISprite));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06033E7C RID: 212604 RVA: 0x00CFD690 File Offset: 0x00CFB890
		[NullableContext(1)]
		public void SetData(TrainingData data)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), data.NameId, Array.Empty<object>());
			base.GetSprite(1).SetFillAmount(data.FillAmount);
			string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(data.Icon);
			this.SetSpriteByPath(resourcePath, base.GetSprite(3), false, null, null);
			UUIText text = base.GetText(2);
			UUISprite sprite = base.GetSprite(4);
			string tipsId = data.TipsId;
			bool flag = tipsId != null && tipsId != "";
			text.SetUIActive(flag);
			sprite.SetUIActive(flag);
			if (flag)
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(text, tipsId, Array.Empty<object>());
				FColor color = FColor.FromHex(data.BgColor);
				sprite.SetColor(color);
			}
		}

		// Token: 0x0200AE2A RID: 44586
		private class EReviveTrainingItemDefine
		{
			// Token: 0x04036166 RID: 221542
			public const int NameText = 0;

			// Token: 0x04036167 RID: 221543
			public const int ProcessSprite = 1;

			// Token: 0x04036168 RID: 221544
			public const int TipText = 2;

			// Token: 0x04036169 RID: 221545
			public const int IconSprite = 3;

			// Token: 0x0403616A RID: 221546
			public const int BgSprite = 4;
		}
	}
}
