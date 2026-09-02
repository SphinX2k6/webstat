using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Roverlike
{
	// Token: 0x020063B9 RID: 25529
	public class RoverlikeBlessingSuitBlessItem : GridProxyAbstract<int>
	{
		// Token: 0x060401E2 RID: 262626 RVA: 0x0106F6BB File Offset: 0x0106D8BB
		[NullableContext(1)]
		public void BindOnItemClick(Action<int> callback)
		{
			this.OnItemClick = callback;
		}

		// Token: 0x060401E3 RID: 262627 RVA: 0x0106F6C4 File Offset: 0x0106D8C4
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
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIExtendToggle));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(2, new Action<EToggleState>(this.OnTogBlessingStateChanged));
			this.BtnBindInfo = list2;
		}

		// Token: 0x060401E4 RID: 262628 RVA: 0x0106F78B File Offset: 0x0106D98B
		protected override void OnStart()
		{
		}

		// Token: 0x060401E5 RID: 262629 RVA: 0x0106F790 File Offset: 0x0106D990
		public override void Refresh(int blessId, bool isSelected, int gridIndex)
		{
			this.CurrentBlessId = blessId;
			RoverRogueBless? blessConfig = ConfigBase<RoverlikeConfig>.Instance.GetBlessConfig(blessId);
			if (blessConfig == null)
			{
				return;
			}
			this.SetSpriteByPath(blessConfig.Value.Icon, base.GetSprite(1), false, null, null);
			RoverRogueQuality? qualityConfig = ConfigBase<RoverlikeConfig>.Instance.GetQualityConfig(blessConfig.Value.Quality);
			if (qualityConfig != null)
			{
				UUISprite sprite = base.GetSprite(0);
				if (sprite != null)
				{
					sprite.SetColor(FColor.FromHex(qualityConfig.Value.BlessSuitIcon));
				}
			}
			UUIExtendToggle extendToggle = base.GetExtendToggle(2);
			if (extendToggle == null)
			{
				return;
			}
			extendToggle.SetToggleStateForce(isSelected ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, false, false, false);
		}

		// Token: 0x060401E6 RID: 262630 RVA: 0x0106F846 File Offset: 0x0106DA46
		private void OnTogBlessingStateChanged(EToggleState state)
		{
			if (state == EToggleState.ETT_Checked && this.CurrentBlessId > 0)
			{
				Action<int> onItemClick = this.OnItemClick;
				if (onItemClick == null)
				{
					return;
				}
				onItemClick(this.CurrentBlessId);
			}
		}

		// Token: 0x060401E7 RID: 262631 RVA: 0x0106F86B File Offset: 0x0106DA6B
		public override void OnSelected(bool fireEvent)
		{
			UUIExtendToggle extendToggle = base.GetExtendToggle(2);
			if (extendToggle == null)
			{
				return;
			}
			extendToggle.SetToggleStateForce(EToggleState.ETT_Checked, false, false, false);
		}

		// Token: 0x060401E8 RID: 262632 RVA: 0x0106F882 File Offset: 0x0106DA82
		public override void OnDeselected(bool fireEvent)
		{
			UUIExtendToggle extendToggle = base.GetExtendToggle(2);
			if (extendToggle == null)
			{
				return;
			}
			extendToggle.SetToggleStateForce(EToggleState.ETT_UnChecked, false, false, false);
		}

		// Token: 0x060401E9 RID: 262633 RVA: 0x0106F899 File Offset: 0x0106DA99
		[NullableContext(1)]
		public override object GetKey(int data, int displayIndex)
		{
			return data;
		}

		// Token: 0x04023FBF RID: 147391
		private int CurrentBlessId;

		// Token: 0x04023FC0 RID: 147392
		[Nullable(2)]
		private Action<int> OnItemClick;

		// Token: 0x0200C421 RID: 50209
		private class EComponents
		{
			// Token: 0x0403C623 RID: 247331
			public const int SpriteBg = 0;

			// Token: 0x0403C624 RID: 247332
			public const int SpriteBlessIcon = 1;

			// Token: 0x0403C625 RID: 247333
			public const int TogBlessing = 2;
		}
	}
}
