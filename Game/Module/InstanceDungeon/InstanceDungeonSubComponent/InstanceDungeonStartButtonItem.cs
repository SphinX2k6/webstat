using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.InstanceDungeon.InstanceDungeonSubComponent
{
	// Token: 0x02005BF7 RID: 23543
	[NullableContext(2)]
	[Nullable(0)]
	public class InstanceDungeonStartButtonItem : UiPanelBase
	{
		// Token: 0x0603B944 RID: 244036 RVA: 0x00F1A524 File Offset: 0x00F18724
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIButtonComponent));
			this.ComponentRegisterInfos = list;
			num2 = 3;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(1, new Action(this.OnClickBtnSolo));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnClickBtnMultiple));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(2, new Action(this.OnClickBtnTeam));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603B945 RID: 244037 RVA: 0x00F1A634 File Offset: 0x00F18834
		public void RefreshItem(InstOnlineType instanceOnlineType)
		{
			this.SetActive(true);
			if (ModelBase<GameModeModel>.Instance.IsMulti && !ModelBase<OnlineModel>.Instance.GetIsMyTeam())
			{
				base.SetButtonUiActive(0, false);
				base.SetButtonUiActive(1, false);
				base.SetButtonUiActive(2, false);
				return;
			}
			if (instanceOnlineType == InstOnlineType.Single)
			{
				base.SetButtonUiActive(0, false);
				base.SetButtonUiActive(1, true);
				base.SetButtonUiActive(2, false);
				return;
			}
			if (instanceOnlineType == InstOnlineType.Multi)
			{
				base.SetButtonUiActive(0, true);
				base.SetButtonUiActive(1, false);
				if (ModelBase<GameModeModel>.Instance.IsMulti)
				{
					base.SetButtonUiActive(2, true);
					return;
				}
				base.SetButtonUiActive(2, false);
				return;
			}
			else
			{
				base.SetButtonUiActive(0, true);
				if (!ModelBase<GameModeModel>.Instance.IsMulti)
				{
					base.SetButtonUiActive(1, true);
					base.SetButtonUiActive(2, false);
					return;
				}
				base.SetButtonUiActive(1, false);
				base.SetButtonUiActive(2, true);
				return;
			}
		}

		// Token: 0x0603B946 RID: 244038 RVA: 0x00F1A6FD File Offset: 0x00F188FD
		public void OnClickBtnSolo()
		{
			if (!this.GetIsAllowedClickBegin())
			{
				return;
			}
			this.NextCanClickButtonTime = Singleton<TimeUtil>.Instance.GetServerTimeStamp() + 500.0;
			Action onClickBtnSoloCallBack = this.OnClickBtnSoloCallBack;
			if (onClickBtnSoloCallBack == null)
			{
				return;
			}
			onClickBtnSoloCallBack();
		}

		// Token: 0x0603B947 RID: 244039 RVA: 0x00F1A732 File Offset: 0x00F18932
		private void OnClickBtnMultiple()
		{
			if (!this.GetIsAllowedClickBegin())
			{
				return;
			}
			this.NextCanClickButtonTime = Singleton<TimeUtil>.Instance.GetServerTimeStamp() + 500.0;
			Action onClickBtnMultipleCallBack = this.OnClickBtnMultipleCallBack;
			if (onClickBtnMultipleCallBack == null)
			{
				return;
			}
			onClickBtnMultipleCallBack();
		}

		// Token: 0x0603B948 RID: 244040 RVA: 0x00F1A767 File Offset: 0x00F18967
		private void OnClickBtnTeam()
		{
			if (!this.GetIsAllowedClickBegin())
			{
				return;
			}
			this.NextCanClickButtonTime = Singleton<TimeUtil>.Instance.GetServerTimeStamp() + 500.0;
			Action onClickBtnTeamCallBack = this.OnClickBtnTeamCallBack;
			if (onClickBtnTeamCallBack == null)
			{
				return;
			}
			onClickBtnTeamCallBack();
		}

		// Token: 0x0603B949 RID: 244041 RVA: 0x00F1A79C File Offset: 0x00F1899C
		private bool GetIsAllowedClickBegin()
		{
			return this.NextCanClickButtonTime <= Singleton<TimeUtil>.Instance.GetServerTimeStamp();
		}

		// Token: 0x04021898 RID: 137368
		private double NextCanClickButtonTime;

		// Token: 0x04021899 RID: 137369
		public Action OnClickBtnSoloCallBack;

		// Token: 0x0402189A RID: 137370
		public Action OnClickBtnMultipleCallBack;

		// Token: 0x0402189B RID: 137371
		public Action OnClickBtnTeamCallBack;

		// Token: 0x0402189C RID: 137372
		private const int CLICK_INSTANCE_BEGIN_BUTTON_CD = 500;

		// Token: 0x0200BC6D RID: 48237
		[NullableContext(0)]
		private enum EChildType
		{
			// Token: 0x0403A19B RID: 237979
			BtnMultiple,
			// Token: 0x0403A19C RID: 237980
			BtnSolo,
			// Token: 0x0403A19D RID: 237981
			BtnTeam
		}
	}
}
