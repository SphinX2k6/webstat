using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Roverlike
{
	// Token: 0x02006435 RID: 25653
	[NullableContext(2)]
	[Nullable(0)]
	public class RoverlikeRoleUnlockView : UiViewBase
	{
		// Token: 0x17009DF8 RID: 40440
		// (get) Token: 0x06040680 RID: 263808 RVA: 0x01082E5F File Offset: 0x0108105F
		private RoverlikeRoleUnlockViewParam Param
		{
			get
			{
				return this.OpenParam as RoverlikeRoleUnlockViewParam;
			}
		}

		// Token: 0x06040681 RID: 263809 RVA: 0x01082E6C File Offset: 0x0108106C
		[NullableContext(1)]
		public RoverlikeRoleUnlockView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x06040682 RID: 263810 RVA: 0x01082E78 File Offset: 0x01081078
		protected unsafe override void OnRegisterComponent()
		{
			int num = 5;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnCloseClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06040683 RID: 263811 RVA: 0x01082F81 File Offset: 0x01081181
		protected override void OnStart()
		{
			RoverlikeRoleUnlockViewParam param = this.Param;
			this.OnClosed = ((param != null) ? param.OnClosed : null);
			RoverlikeRoleUnlockViewParam param2 = this.Param;
			this.RefreshByBlessRole((param2 != null) ? param2.BlessRoleId : 0);
		}

		// Token: 0x06040684 RID: 263812 RVA: 0x01082FB3 File Offset: 0x010811B3
		protected override void OnBeforeDestroy()
		{
			Action onClosed = this.OnClosed;
			this.OnClosed = null;
			if (onClosed == null)
			{
				return;
			}
			onClosed();
		}

		// Token: 0x06040685 RID: 263813 RVA: 0x01082FCC File Offset: 0x010811CC
		private void RefreshByBlessRole(int blessRoleId)
		{
			RoverRogueBlessRole? blessRoleConfig = ConfigBase<RoverlikeConfig>.Instance.GetBlessRoleConfig(blessRoleId);
			if (blessRoleConfig == null)
			{
				return;
			}
			base.SetTextureShowUntilLoaded(blessRoleConfig.Value.UnlockStand, base.GetTexture(2), null);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), blessRoleConfig.Value.BlessRoleName, Array.Empty<object>());
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), blessRoleConfig.Value.SkillDesc, Array.Empty<object>());
		}

		// Token: 0x06040686 RID: 263814 RVA: 0x01083056 File Offset: 0x01081256
		private void OnCloseClick()
		{
			base.CloseMe(null);
		}

		// Token: 0x04024125 RID: 147749
		private Action OnClosed;

		// Token: 0x0200C4AA RID: 50346
		[NullableContext(0)]
		private class EComponents
		{
			// Token: 0x0403C884 RID: 247940
			public const int SprClose = 0;

			// Token: 0x0403C885 RID: 247941
			public const int PnlRole = 1;

			// Token: 0x0403C886 RID: 247942
			public const int TexRole = 2;

			// Token: 0x0403C887 RID: 247943
			public const int TxtName1 = 3;

			// Token: 0x0403C888 RID: 247944
			public const int TxtName2 = 4;
		}
	}
}
