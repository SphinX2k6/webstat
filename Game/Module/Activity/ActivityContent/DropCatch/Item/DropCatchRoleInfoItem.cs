using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.DropCatch.Item
{
	// Token: 0x020068EF RID: 26863
	public class DropCatchRoleInfoItem : GridProxyAbstract<float>
	{
		// Token: 0x06042C04 RID: 273412 RVA: 0x011218A4 File Offset: 0x0111FAA4
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUISprite)),
				new ValueTuple<int, Type>(1, typeof(UUIText)),
				new ValueTuple<int, Type>(2, typeof(UUIGridLayout)),
				new ValueTuple<int, Type>(3, typeof(UUIItem))
			};
		}

		// Token: 0x06042C05 RID: 273413 RVA: 0x01121914 File Offset: 0x0111FB14
		protected override void OnStart()
		{
			this.ValueLayout = new GenericLayout<DropCatchRoleBarItem, int>(base.GetGridLayout(2), new Func<DropCatchRoleBarItem>(this.InitBarItem), null, false, true);
		}

		// Token: 0x06042C06 RID: 273414 RVA: 0x01121937 File Offset: 0x0111FB37
		[NullableContext(1)]
		private DropCatchRoleBarItem InitBarItem()
		{
			return new DropCatchRoleBarItem();
		}

		// Token: 0x06042C07 RID: 273415 RVA: 0x01121940 File Offset: 0x0111FB40
		public override void Refresh(float curValue, bool isSelected, int gridIndex)
		{
			List<int> list = new List<int>();
			for (int i = 0; i < 5; i++)
			{
				if ((float)i < curValue)
				{
					list.Add(i);
				}
			}
			string text = null;
			string text2 = null;
			switch (gridIndex)
			{
			case 0:
				text = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("SP_GoldCatchIconSpeed");
				text2 = "CoinCatch_Character_Speed";
				break;
			case 1:
				text = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("SP_GoldCatchIconRange");
				text2 = "CoinCatch_Character_Range";
				break;
			case 2:
				text = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("SP_GoldCatchIconCharge");
				text2 = "CoinCatch_Character_Energy";
				break;
			}
			if (!string.IsNullOrEmpty(text))
			{
				this.SetSpriteByPath(text, base.GetSprite(0), false, null, null);
			}
			if (!string.IsNullOrEmpty(text2))
			{
				UUIText text3 = base.GetText(1);
				if (text3 != null)
				{
					text3.ShowTextNew(text2);
				}
			}
			GenericLayout<DropCatchRoleBarItem, int> valueLayout = this.ValueLayout;
			if (valueLayout == null)
			{
				return;
			}
			valueLayout.RefreshByData(list, null, false);
		}

		// Token: 0x0402530E RID: 152334
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private GenericLayout<DropCatchRoleBarItem, int> ValueLayout;

		// Token: 0x0402530F RID: 152335
		private const int MAX_ROLE_INFO_VALUE = 5;
	}
}
