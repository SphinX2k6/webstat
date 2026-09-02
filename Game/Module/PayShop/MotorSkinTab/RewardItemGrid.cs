using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.PayShop.MotorSkinTab
{
	// Token: 0x020056C0 RID: 22208
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class RewardItemGrid : GridProxyAbstract<IRewardItemGridData>
	{
		// Token: 0x06038869 RID: 231529 RVA: 0x00E521E8 File Offset: 0x00E503E8
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(1, typeof(UUITexture)),
				new ValueTuple<int, Type>(2, typeof(UUIText))
			};
		}

		// Token: 0x0603886A RID: 231530 RVA: 0x00E52244 File Offset: 0x00E50444
		[NullableContext(1)]
		public override void Refresh(IRewardItemGridData data, bool isSelected, int gridIndex)
		{
			base.SetTextureByPath(data.IconPath, base.GetTexture(1), null, null);
			string multiTextByKey = ConfigBase<TextConfig>.Instance.GetMultiTextByKey("MotorShop_Xicon", "x");
			UUIText text = base.GetText(2);
			if (text == null)
			{
				return;
			}
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 2);
			defaultInterpolatedStringHandler.AppendFormatted(multiTextByKey);
			defaultInterpolatedStringHandler.AppendFormatted<int>(data.Count);
			text.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
		}

		// Token: 0x0200B72F RID: 46895
		private enum ERewardItemComponents
		{
			// Token: 0x04038A94 RID: 232084
			BtnReward01,
			// Token: 0x04038A95 RID: 232085
			TexIcon,
			// Token: 0x04038A96 RID: 232086
			TxtNum
		}
	}
}
