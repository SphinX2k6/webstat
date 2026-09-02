using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.CyberPunk
{
	// Token: 0x02006969 RID: 26985
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class AdamSmasherStageItem : GridProxyAbstract<IAdamSmasherStageItemData>
	{
		// Token: 0x06042F59 RID: 274265 RVA: 0x01130C9C File Offset: 0x0112EE9C
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(3, typeof(UUIItem)),
				new ValueTuple<int, Type>(4, typeof(UUIItem)),
				new ValueTuple<int, Type>(5, typeof(UUIItem)),
				new ValueTuple<int, Type>(6, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIText)),
				new ValueTuple<int, Type>(2, typeof(UUIText)),
				new ValueTuple<int, Type>(7, typeof(UUIItem)),
				new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
				new ValueTuple<int, Type>(8, typeof(UUIItem)),
				new ValueTuple<int, Type>(9, typeof(UUIItem)),
				new ValueTuple<int, Type>(10, typeof(UUISprite)),
				new ValueTuple<int, Type>(11, typeof(UUISprite))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnToggleClick))
			};
		}

		// Token: 0x06042F5A RID: 274266 RVA: 0x01130DE2 File Offset: 0x0112EFE2
		public int GetStageId()
		{
			IAdamSmasherStageItemData stageData = this.StageData;
			if (stageData == null)
			{
				return 0;
			}
			return stageData.StageId;
		}

		// Token: 0x06042F5B RID: 274267 RVA: 0x01130DF8 File Offset: 0x0112EFF8
		public override void Refresh(IAdamSmasherStageItemData data, bool isSelected, int gridIndex)
		{
			this.StageData = data;
			UUIText text = base.GetText(1);
			if (text != null)
			{
				text.SetText(data.IsHard ? "" : data.IndexText, true);
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), data.Name, Array.Empty<object>());
			base.GetText(1).useChangeColor = (data.IsUnlocked && !data.IsHard);
			base.GetText(2).useChangeColor = (data.IsUnlocked && !data.IsHard);
			base.GetText(2).SetColor(data.IsHard ? FColor.FromHex("#ff606f") : FColor.FromHex("#666666FF"));
			UUIItem item = base.GetItem(3);
			if (item != null)
			{
				item.SetUIActive(!data.IsUnlocked && !data.IsHard);
			}
			UUIItem item2 = base.GetItem(4);
			if (item2 != null)
			{
				item2.SetUIActive(data.IsUnlocked && !data.IsHard);
			}
			UUIItem item3 = base.GetItem(6);
			if (item3 != null)
			{
				item3.SetUIActive(ControllerBase<AdamSmasherController>.Instance.IsStageCleared(data.StageId));
			}
			UUIItem item4 = base.GetItem(8);
			if (item4 != null)
			{
				item4.SetUIActive(data.IsHard);
			}
			UUIItem item5 = base.GetItem(9);
			if (item5 != null)
			{
				item5.SetUIActive(data.IsHard && !data.IsUnlocked);
			}
			this.RefreshDecorationSprite(data);
		}

		// Token: 0x06042F5C RID: 274268 RVA: 0x01130F70 File Offset: 0x0112F170
		public void RefreshDecorationSprite(IAdamSmasherStageItemData data)
		{
			string path = "/Game/Aki/UI/UIResources/UiActivity/Atlas/Activity34/Cyberpunk/Challenge" + (data.IsHard ? "/SP_TogLevelSelDecoSP.SP_TogLevelSelDecoSP" : "/SP_TogLevelSelDecoNor.SP_TogLevelSelDecoNor");
			this.SetSpriteByPath(path, base.GetSprite(10), false, null, null);
			string path2 = "/Game/Aki/UI/UIResources/UiActivity/Atlas/Activity34/Cyberpunk/Challenge" + (data.IsHard ? "/SP_IconTogFinishSP.SP_IconTogFinishSP" : "/SP_IconTogFinishNor.SP_IconTogFinishNor");
			this.SetSpriteByPath(path2, base.GetSprite(11), false, null, null);
		}

		// Token: 0x06042F5D RID: 274269 RVA: 0x01130FF0 File Offset: 0x0112F1F0
		public void SetToggleActive(bool selected)
		{
			if (this.StageData == null)
			{
				return;
			}
			EToggleState state = selected ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
			UUIExtendToggle extendToggle = base.GetExtendToggle(0);
			if (extendToggle != null)
			{
				extendToggle.SetToggleState(state, false, false, false);
			}
			bool useChangeColor = (selected || this.StageData.IsUnlocked) && !this.StageData.IsHard;
			base.GetText(1).useChangeColor = useChangeColor;
			base.GetText(2).useChangeColor = useChangeColor;
		}

		// Token: 0x06042F5E RID: 274270 RVA: 0x01131061 File Offset: 0x0112F261
		private void OnToggleClick(EToggleState state)
		{
			if (this.StageData == null)
			{
				return;
			}
			AdamSmasherSelectView adamSmasherSelectView = Singleton<UiManager>.Instance.GetViewByName(EUiViewName.AdamSmasherSelectView) as AdamSmasherSelectView;
			if (adamSmasherSelectView == null)
			{
				return;
			}
			adamSmasherSelectView.ChangeStageId(this.StageData.StageId);
		}

		// Token: 0x040254D0 RID: 152784
		private const string NormalColor = "#666666FF";

		// Token: 0x040254D1 RID: 152785
		private const string HardColor = "#ff606f";

		// Token: 0x040254D2 RID: 152786
		[Nullable(2)]
		public Action<int> OnStageClick;

		// Token: 0x040254D3 RID: 152787
		[Nullable(2)]
		private IAdamSmasherStageItemData StageData;

		// Token: 0x0200C910 RID: 51472
		[NullableContext(0)]
		private enum EStageItemComponent
		{
			// Token: 0x0403DD99 RID: 253337
			ToggleBtn,
			// Token: 0x0403DD9A RID: 253338
			IndexText,
			// Token: 0x0403DD9B RID: 253339
			NameText,
			// Token: 0x0403DD9C RID: 253340
			LockPanel,
			// Token: 0x0403DD9D RID: 253341
			NormalPanel,
			// Token: 0x0403DD9E RID: 253342
			SelectItem,
			// Token: 0x0403DD9F RID: 253343
			FinishItem,
			// Token: 0x0403DDA0 RID: 253344
			RedDot,
			// Token: 0x0403DDA1 RID: 253345
			BossPanel,
			// Token: 0x0403DDA2 RID: 253346
			BossLockPanel,
			// Token: 0x0403DDA3 RID: 253347
			DecorationSprite,
			// Token: 0x0403DDA4 RID: 253348
			FinishSprite
		}
	}
}
