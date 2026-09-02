using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Coop
{
	// Token: 0x0200699F RID: 27039
	[NullableContext(2)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class CoopRoleItem : GridProxyAbstract<CoopRoleData>
	{
		// Token: 0x06043129 RID: 274729 RVA: 0x0113A252 File Offset: 0x01138452
		[NullableContext(1)]
		public CoopRoleItem(CoopActivityData activityData)
		{
			this.ActivityData = activityData;
		}

		// Token: 0x0604312A RID: 274730 RVA: 0x0113A264 File Offset: 0x01138464
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
				new ValueTuple<int, Type>(1, typeof(UUITexture)),
				new ValueTuple<int, Type>(2, typeof(UUIItem)),
				new ValueTuple<int, Type>(3, typeof(UUIItem)),
				new ValueTuple<int, Type>(4, typeof(UUIItem)),
				new ValueTuple<int, Type>(5, typeof(UUIItem))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnTogClick))
			};
		}

		// Token: 0x0604312B RID: 274731 RVA: 0x0113A323 File Offset: 0x01138523
		protected override void OnStart()
		{
			this.SeqPlayer = new LevelSequencePlayer(this.RootItem);
			base.GetExtendToggle(0).CanExecuteChange.Bind(() => this.CanExecuteChangeFunc == null || this.CanExecuteChangeFunc(base.GridIndex));
		}

		// Token: 0x0604312C RID: 274732 RVA: 0x0113A353 File Offset: 0x01138553
		protected override void OnBeforeDestroy()
		{
			LevelSequencePlayer seqPlayer = this.SeqPlayer;
			if (seqPlayer != null)
			{
				seqPlayer.Clear();
			}
			this.SeqPlayer = null;
		}

		// Token: 0x0604312D RID: 274733 RVA: 0x0113A36D File Offset: 0x0113856D
		private void OnTogClick(EToggleState _)
		{
			Action<int, CoopRoleData> onTogClickCallBack = this.OnTogClickCallBack;
			if (onTogClickCallBack == null)
			{
				return;
			}
			onTogClickCallBack(base.GridIndex, this.Data);
		}

		// Token: 0x0604312E RID: 274734 RVA: 0x0113A38C File Offset: 0x0113858C
		[NullableContext(1)]
		public override void Refresh(CoopRoleData data, bool isSelected, int gridIndex)
		{
			this.Data = data;
			bool isUnLock = data.IsUnLock;
			if (isUnLock)
			{
				base.SetTextureByPath(data.IconPath, base.GetTexture(1), null, null);
			}
			base.GetItem(5).SetUIActive(this.ActivityData.IsRoleHasRedDot(data.RoleId));
			base.GetItem(2).SetUIActive(isUnLock);
			base.GetItem(3).SetUIActive(!isUnLock);
			base.GetItem(4).SetUIActive(data.IsMaxLevel);
		}

		// Token: 0x0604312F RID: 274735 RVA: 0x0113A414 File Offset: 0x01138614
		public override void OnSelected(bool fireEvent)
		{
			LevelSequencePlayer seqPlayer = this.SeqPlayer;
			if (seqPlayer != null)
			{
				seqPlayer.PlayLevelSequenceByName("Select", false, null, false);
			}
			this.SetToggleState(true);
		}

		// Token: 0x06043130 RID: 274736 RVA: 0x0113A449 File Offset: 0x01138649
		public override void OnDeselected(bool fireEvent)
		{
			LevelSequencePlayer seqPlayer = this.SeqPlayer;
			if (seqPlayer != null)
			{
				seqPlayer.StopSequenceByKey("Select", false, false);
			}
			this.SetToggleState(false);
		}

		// Token: 0x06043131 RID: 274737 RVA: 0x0113A46C File Offset: 0x0113866C
		private void SetToggleState(bool state)
		{
			EToggleState state2 = state ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
			base.GetExtendToggle(0).SetToggleState(state2, false, false, false);
		}

		// Token: 0x040255FF RID: 153087
		public CoopRoleData Data;

		// Token: 0x04025600 RID: 153088
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public Action<int, CoopRoleData> OnTogClickCallBack;

		// Token: 0x04025601 RID: 153089
		public Func<int, bool> CanExecuteChangeFunc;

		// Token: 0x04025602 RID: 153090
		private LevelSequencePlayer SeqPlayer;

		// Token: 0x04025603 RID: 153091
		private readonly CoopActivityData ActivityData;
	}
}
