using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Roverlike
{
	// Token: 0x020063BA RID: 25530
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class RoverlikeBlessingSuitItem : GridProxyAbstract<IRoverlikeBlessingSuitData>
	{
		// Token: 0x060401EB RID: 262635 RVA: 0x0106F8A9 File Offset: 0x0106DAA9
		public void BindOnSuitClick(Action<IRoverlikeBlessingSuitData> callback)
		{
			this.OnSuitClick = callback;
		}

		// Token: 0x060401EC RID: 262636 RVA: 0x0106F8B4 File Offset: 0x0106DAB4
		protected unsafe override void OnRegisterComponent()
		{
			int num = 6;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIHorizontalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUITexture));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnBtnRoleClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x060401ED RID: 262637 RVA: 0x0106F9E0 File Offset: 0x0106DBE0
		public override void Refresh(IRoverlikeBlessingSuitData data, bool isSelected, int gridIndex)
		{
			this.CurrentData = data;
			RoverRogueBlessGroup? blessGroupConfig = ConfigBase<RoverlikeConfig>.Instance.GetBlessGroupConfig(data.SuitId);
			if (blessGroupConfig != null)
			{
				RoverRogueBlessRole? blessRoleConfig = ConfigBase<RoverlikeConfig>.Instance.GetBlessRoleConfig(blessGroupConfig.Value.BlessRoleId);
				if (blessRoleConfig != null)
				{
					Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), blessRoleConfig.Value.BlessRoleName, Array.Empty<object>());
					base.SetTextureShowUntilLoaded(blessRoleConfig.Value.Stand, base.GetTexture(2), null);
					base.SetTextureByPath(blessRoleConfig.Value.IconPath, base.GetTexture(5), null, null);
				}
			}
			this.RefreshSkillLayout(data.BlessingIdList);
		}

		// Token: 0x060401EE RID: 262638 RVA: 0x0106FAA9 File Offset: 0x0106DCA9
		private void OnBtnRoleClick()
		{
			if (this.CurrentData != null)
			{
				Action<IRoverlikeBlessingSuitData> onSuitClick = this.OnSuitClick;
				if (onSuitClick == null)
				{
					return;
				}
				onSuitClick(this.CurrentData);
			}
		}

		// Token: 0x060401EF RID: 262639 RVA: 0x0106FAC9 File Offset: 0x0106DCC9
		private RoverlikeBlessingSuitBlessItem CreateSkillItem()
		{
			return new RoverlikeBlessingSuitBlessItem();
		}

		// Token: 0x060401F0 RID: 262640 RVA: 0x0106FAD0 File Offset: 0x0106DCD0
		private void RefreshSkillLayout(List<int> blessingIdList)
		{
			this.SkillLayout.RefreshByData(blessingIdList, null, false);
		}

		// Token: 0x060401F1 RID: 262641 RVA: 0x0106FAE0 File Offset: 0x0106DCE0
		protected override void OnStart()
		{
			this.SkillLayout = new GenericLayout<RoverlikeBlessingSuitBlessItem, int>(base.GetHorizontalLayout(3), new Func<RoverlikeBlessingSuitBlessItem>(this.CreateSkillItem), null, false, true);
		}

		// Token: 0x060401F2 RID: 262642 RVA: 0x0106FB03 File Offset: 0x0106DD03
		protected override void OnBeforeDestroy()
		{
			this.OnSuitClick = null;
		}

		// Token: 0x04023FC1 RID: 147393
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private GenericLayout<RoverlikeBlessingSuitBlessItem, int> SkillLayout;

		// Token: 0x04023FC2 RID: 147394
		[Nullable(2)]
		private IRoverlikeBlessingSuitData CurrentData;

		// Token: 0x04023FC3 RID: 147395
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private Action<IRoverlikeBlessingSuitData> OnSuitClick;

		// Token: 0x0200C422 RID: 50210
		[NullableContext(0)]
		private class EComponents
		{
			// Token: 0x0403C626 RID: 247334
			public const int BtnRole = 0;

			// Token: 0x0403C627 RID: 247335
			public const int TxtRoleName = 1;

			// Token: 0x0403C628 RID: 247336
			public const int TexRole = 2;

			// Token: 0x0403C629 RID: 247337
			public const int SkillLayout = 3;

			// Token: 0x0403C62A RID: 247338
			public const int SkillItem = 4;

			// Token: 0x0403C62B RID: 247339
			public const int TexIconType = 5;
		}
	}
}
