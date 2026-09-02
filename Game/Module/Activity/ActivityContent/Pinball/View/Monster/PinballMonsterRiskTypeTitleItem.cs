using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Pinball.View.Monster
{
	// Token: 0x020065EE RID: 26094
	public class PinballMonsterRiskTypeTitleItem : SyncGridProxyAbstract<PinballMonsterRiskType>
	{
		// Token: 0x06041314 RID: 267028 RVA: 0x010B9B4C File Offset: 0x010B7D4C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06041315 RID: 267029 RVA: 0x010B9BD8 File Offset: 0x010B7DD8
		public override void Refresh(PinballMonsterRiskType data)
		{
			this.Data = new PinballMonsterRiskType?(data);
			this.SetSpriteByPath(data.Icon2, base.GetSprite(1), false, null, null);
			FColor color = FColor.FromHex(data.TitleColor);
			FColor fontOutlineColor = FColor.FromHex(data.TitleOutlineColor);
			UUIText text = base.GetText(2);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text, data.Name, Array.Empty<object>());
			text.SetColor(color);
			text.SetFontOutlineColor(fontOutlineColor);
			base.GetSprite(0).SetColor(color);
		}

		// Token: 0x04024805 RID: 149509
		private PinballMonsterRiskType? Data;

		// Token: 0x0200C5F8 RID: 50680
		private enum EComponents
		{
			// Token: 0x0403CF0A RID: 249610
			BgSprite,
			// Token: 0x0403CF0B RID: 249611
			TypeIconSprite,
			// Token: 0x0403CF0C RID: 249612
			NameText
		}
	}
}
