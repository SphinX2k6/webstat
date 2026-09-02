using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.SpringManor
{
	// Token: 0x02006345 RID: 25413
	public class GetWayItem : GridProxyAbstract<int>
	{
		// Token: 0x0603FD35 RID: 261429 RVA: 0x0105ECFC File Offset: 0x0105CEFC
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(1, typeof(UUISprite)),
				new ValueTuple<int, Type>(2, typeof(UUIText)),
				new ValueTuple<int, Type>(3, typeof(UUIItem)),
				new ValueTuple<int, Type>(4, typeof(UUIItem)),
				new ValueTuple<int, Type>(5, typeof(UUIItem))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(0, new Action(this.OnButtonClick))
			};
		}

		// Token: 0x0603FD36 RID: 261430 RVA: 0x0105EDBB File Offset: 0x0105CFBB
		private void OnButtonClick()
		{
			if (this.State != EGetWayState.Normal || this.SkipEntryId <= 0)
			{
				return;
			}
			SpringManorController instance = ControllerBase<SpringManorController>.Instance;
			if (instance == null)
			{
				return;
			}
			instance.ExecuteSkipEntry(this.SkipEntryId, this.OnTrackPositionCallback);
		}

		// Token: 0x0603FD37 RID: 261431 RVA: 0x0105EDEC File Offset: 0x0105CFEC
		public override void Refresh(int data, bool isSelected, int gridIndex)
		{
			this.SkipEntryId = data;
			SpringFestivalSkipEntry? skipEntryConfigById = ConfigBase<SpringManorConfig>.Instance.GetSkipEntryConfigById(data);
			if (skipEntryConfigById == null)
			{
				return;
			}
			UUIText text = base.GetText(2);
			if (text != null)
			{
				text.ShowTextNew(skipEntryConfigById.Value.Name);
			}
			if (!ModelBase<SpringManorModel>.Instance.ActivityData.IsSkipEntryUnLock(data))
			{
				this.RefreshState(EGetWayState.Lock);
				return;
			}
			if (ModelBase<SpringManorModel>.Instance.ActivityData.IsSkipEntryFinish(data))
			{
				this.RefreshState(EGetWayState.Finish);
				return;
			}
			bool flag = skipEntryConfigById.Value.JumpId > 0;
			bool flag2 = skipEntryConfigById.Value.TrackPositionLength > 0;
			this.RefreshState((flag || flag2) ? EGetWayState.Normal : EGetWayState.CantJump);
		}

		// Token: 0x0603FD38 RID: 261432 RVA: 0x0105EEA0 File Offset: 0x0105D0A0
		private void RefreshState(EGetWayState state)
		{
			this.State = state;
			UUIButtonComponent button = base.GetButton(0);
			if (button != null)
			{
				button.SetSelfInteractive(state != EGetWayState.Lock && state != EGetWayState.CantJump);
			}
			UUIItem item = base.GetItem(3);
			if (item != null)
			{
				item.SetUIActive(state == EGetWayState.Normal);
			}
			UUIItem item2 = base.GetItem(4);
			if (item2 != null)
			{
				item2.SetUIActive(state == EGetWayState.Lock);
			}
			UUIItem item3 = base.GetItem(5);
			if (item3 == null)
			{
				return;
			}
			item3.SetUIActive(state == EGetWayState.Finish);
		}

		// Token: 0x04023DCD RID: 146893
		private int SkipEntryId;

		// Token: 0x04023DCE RID: 146894
		private EGetWayState State;

		// Token: 0x04023DCF RID: 146895
		[Nullable(2)]
		public Action OnTrackPositionCallback;
	}
}
