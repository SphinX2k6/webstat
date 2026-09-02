using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Roguelike
{
	// Token: 0x020051B7 RID: 20919
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class RoleAttrItem : GridProxyAbstract<AffixEntry>
	{
		// Token: 0x17008C91 RID: 35985
		// (get) Token: 0x06035C8B RID: 220299 RVA: 0x00D86FE0 File Offset: 0x00D851E0
		// (set) Token: 0x06035C8C RID: 220300 RVA: 0x00D86FE8 File Offset: 0x00D851E8
		public AffixEntry AffixEntry { get; set; }

		// Token: 0x06035C8D RID: 220301 RVA: 0x00D86FF1 File Offset: 0x00D851F1
		public override void Refresh(AffixEntry data, bool isSelected, int gridIndex)
		{
			this.Update(data);
		}

		// Token: 0x06035C8E RID: 220302 RVA: 0x00D86FFA File Offset: 0x00D851FA
		public void Update(AffixEntry affixEntry)
		{
			this.AffixEntry = affixEntry;
			this.RefreshPanel();
		}

		// Token: 0x06035C8F RID: 220303 RVA: 0x00D8700C File Offset: 0x00D8520C
		public void SetSecondColor()
		{
			UUIText text = base.GetText(0);
			UUIItem uuiitem = text;
			bool bUseChangeColor = true;
			FColor? fcolor = new FColor?(text.changeColor);
			uuiitem.SetChangeColor(bUseChangeColor, fcolor);
		}

		// Token: 0x06035C90 RID: 220304 RVA: 0x00D87038 File Offset: 0x00D85238
		protected unsafe override void OnRegisterComponent()
		{
			int num = 1;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int index = 0;
			*span[index] = new ValueTuple<int, Type>(0, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06035C91 RID: 220305 RVA: 0x00D87080 File Offset: 0x00D85280
		public void RefreshPanel()
		{
			RogueCharacterBuff? rogueCharacterBuffConfig = ConfigBase<RoguelikeConfig>.Instance.GetRogueCharacterBuffConfig(this.AffixEntry.Id.Value);
			if (rogueCharacterBuffConfig == null)
			{
				return;
			}
			RoguelikeModel instance = ModelBase<RoguelikeModel>.Instance;
			EDescModel? edescModel = (instance != null) ? new EDescModel?(instance.GetDescModel()) : null;
			EDescModel edescModel2 = EDescModel.SIMPLE;
			if (edescModel.GetValueOrDefault() == edescModel2 & edescModel != null)
			{
				base.GetText(0).ShowTextNew(rogueCharacterBuffConfig.Value.AffixDescSimple);
				return;
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), rogueCharacterBuffConfig.Value.AffixDesc, rogueCharacterBuffConfig.Value.AffixDescParam());
		}

		// Token: 0x0200B198 RID: 45464
		[NullableContext(0)]
		private class ERoleAttrItemCom
		{
			// Token: 0x04037134 RID: 225588
			public const int DescText = 0;
		}
	}
}
