using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.RoadBook
{
	// Token: 0x020064C0 RID: 25792
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class TabGridItem : GridProxyAbstract<MotorChallengePlayData>
	{
		// Token: 0x06040A09 RID: 264713 RVA: 0x010910A5 File Offset: 0x0108F2A5
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIItem))
			};
		}

		// Token: 0x06040A0A RID: 264714 RVA: 0x010910E0 File Offset: 0x0108F2E0
		protected override UniTask OnBeforeStartAsync()
		{
			TabGridItem.<OnBeforeStartAsync>d__5 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<TabGridItem.<OnBeforeStartAsync>d__5>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06040A0B RID: 264715 RVA: 0x01091123 File Offset: 0x0108F323
		public void SetItemNewVisible(bool bVisible)
		{
			if (!this.Data.IsUnlock)
			{
				return;
			}
			this.NormalToggle.SetItemNewVisible(bVisible);
		}

		// Token: 0x06040A0C RID: 264716 RVA: 0x01091140 File Offset: 0x0108F340
		public override void Refresh(MotorChallengePlayData data, bool isSelected, int gridIndex)
		{
			this.Data = data;
			if (data.IsUnlock)
			{
				this.NormalToggle.Refresh(data);
			}
			else
			{
				this.LockToggle.Refresh(data);
			}
			if (this.Data.IsUnlock)
			{
				this.NormalToggle.SetIsSelect(isSelected, false);
			}
			else
			{
				this.LockToggle.SetIsSelect(isSelected, false);
			}
			UUIItem item = base.GetItem(0);
			if (item != null)
			{
				item.SetUIActive(data.IsUnlock);
			}
			UUIItem item2 = base.GetItem(1);
			if (item2 == null)
			{
				return;
			}
			item2.SetUIActive(!data.IsUnlock);
		}

		// Token: 0x06040A0D RID: 264717 RVA: 0x010911D1 File Offset: 0x0108F3D1
		public override void OnSelected(bool fireEvent)
		{
			if (this.Data.IsUnlock)
			{
				this.NormalToggle.SetIsSelect(true, fireEvent);
				return;
			}
			this.LockToggle.SetIsSelect(true, fireEvent);
		}

		// Token: 0x04024323 RID: 148259
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		public Action<MotorChallengePlayData, MenuTabToggleItem> OnChildToggleCallback;

		// Token: 0x04024324 RID: 148260
		private MenuTabToggleItem NormalToggle;

		// Token: 0x04024325 RID: 148261
		private MenuTabToggleItem LockToggle;

		// Token: 0x04024326 RID: 148262
		[Nullable(2)]
		private MotorChallengePlayData Data;
	}
}
