using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Anniversary
{
	// Token: 0x020069E3 RID: 27107
	[NullableContext(2)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class AnniversaryActivityEnterItem : GridProxyAbstract<AnniversarySubActivityDataBase>
	{
		// Token: 0x060432FA RID: 275194 RVA: 0x01143AA8 File Offset: 0x01141CA8
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(1, typeof(UUIText)),
				new ValueTuple<int, Type>(2, typeof(UUIItem)),
				new ValueTuple<int, Type>(3, typeof(UUITexture)),
				new ValueTuple<int, Type>(4, typeof(UUIItem)),
				new ValueTuple<int, Type>(5, typeof(UUITexture)),
				new ValueTuple<int, Type>(6, typeof(UUIItem)),
				new ValueTuple<int, Type>(7, typeof(UUIItem)),
				new ValueTuple<int, Type>(8, typeof(UUITexture)),
				new ValueTuple<int, Type>(9, typeof(UUIText)),
				new ValueTuple<int, Type>(10, typeof(UUIItem)),
				new ValueTuple<int, Type>(11, typeof(UUIItem)),
				new ValueTuple<int, Type>(12, typeof(UUIText)),
				new ValueTuple<int, Type>(13, typeof(UUIItem)),
				new ValueTuple<int, Type>(14, typeof(UUITexture))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(0, new Action(this.OnClick))
			};
		}

		// Token: 0x060432FB RID: 275195 RVA: 0x01143C33 File Offset: 0x01141E33
		protected override void OnStart()
		{
			this.SequencePlayer = new LevelSequencePlayer(this.RootItem);
		}

		// Token: 0x060432FC RID: 275196 RVA: 0x01143C46 File Offset: 0x01141E46
		[NullableContext(1)]
		public void SetClickCallback(Action<int> callback)
		{
			this.ClickCallback = callback;
		}

		// Token: 0x060432FD RID: 275197 RVA: 0x01143C4F File Offset: 0x01141E4F
		public override void Refresh(AnniversarySubActivityDataBase data, bool isSelected, int gridIndex)
		{
			this.Refresh(data);
		}

		// Token: 0x060432FE RID: 275198 RVA: 0x01143C58 File Offset: 0x01141E58
		public void Refresh(AnniversarySubActivityDataBase data)
		{
			if (data == null)
			{
				this.SetLockState(true);
				return;
			}
			this.Data = data;
			EAnniversaryActivityState currentState = data.GetCurrentState();
			bool flag = data.NeedPlayUnlockSequence();
			bool lockState = currentState == EAnniversaryActivityState.Lock || currentState == EAnniversaryActivityState.Close || flag;
			AnniversaryEntrance? anniversaryEntranceById = ConfigBase<AnniversaryActivityConfig>.Instance.GetAnniversaryEntranceById((int)data.GetSubId());
			if (anniversaryEntranceById != null)
			{
				base.SetTextureByPath(anniversaryEntranceById.Value.IconPath, base.GetTexture(3), null, null);
			}
			Activity? activityConfig = ConfigBase<ActivityConfig>.Instance.GetActivityConfig(data.GetActivityId());
			if (activityConfig != null)
			{
				UUIText text = base.GetText(12);
				if (text != null)
				{
					text.ShowTextNew(activityConfig.Value.Title);
				}
			}
			UUIItem item = base.GetItem(6);
			if (item != null)
			{
				item.SetUIActive(false);
			}
			this.SetLockState(lockState);
			UUIItem item2 = base.GetItem(4);
			if (item2 != null)
			{
				item2.SetUIActive(false);
			}
			UUITexture texture = base.GetTexture(5);
			if (texture != null)
			{
				texture.SetUIActive(false);
			}
			this.RefreshRedDotItem();
			this.RefreshFinished();
			this.ChildUpdateStateInfo();
			this.OnTipsTimerTick();
		}

		// Token: 0x060432FF RID: 275199 RVA: 0x01143D6C File Offset: 0x01141F6C
		public void OnTipsTimerTick()
		{
			AnniversarySubActivityDataBase data = this.Data;
			EAnniversaryActivityState? eanniversaryActivityState = (data != null) ? new EAnniversaryActivityState?(data.GetCurrentState()) : null;
			EAnniversaryActivityState eanniversaryActivityState2 = EAnniversaryActivityState.Lock;
			if (eanniversaryActivityState.GetValueOrDefault() == eanniversaryActivityState2 & eanniversaryActivityState != null)
			{
				this.RefreshTimeText();
				return;
			}
			this.ChildUpdateTips();
		}

		// Token: 0x06043300 RID: 275200 RVA: 0x01143DBC File Offset: 0x01141FBC
		public void RefreshTimeText()
		{
			if (this.Data == null)
			{
				return;
			}
			long getUnlockTime = this.Data.GetUnlockTime;
			double serverTime = Singleton<TimeUtil>.Instance.GetServerTime();
			UUIText text = base.GetText(1);
			if (text != null)
			{
				text.SetUIActive(getUnlockTime > 0L && serverTime < (double)getUnlockTime);
			}
			if (getUnlockTime > 0L && serverTime < (double)getUnlockTime)
			{
				string text2 = ConfigBase<TextConfig>.Instance.GetMultiTextByKey("Activity_Anniversary2 _Countdown") ?? "";
				string remainTimeText = ModelBase<ActivityModel>.Instance.GetRemainTimeText(getUnlockTime, text2);
				if (!string.IsNullOrEmpty(remainTimeText))
				{
					UUIText text3 = base.GetText(1);
					if (text3 == null)
					{
						return;
					}
					text3.SetText(remainTimeText, true);
				}
			}
		}

		// Token: 0x06043301 RID: 275201 RVA: 0x01143E53 File Offset: 0x01142053
		private void OnClick()
		{
			if (this.Data == null)
			{
				return;
			}
			Action<int> clickCallback = this.ClickCallback;
			if (clickCallback == null)
			{
				return;
			}
			clickCallback((int)this.Data.GetSubId());
		}

		// Token: 0x06043302 RID: 275202 RVA: 0x01143E7C File Offset: 0x0114207C
		public UniTask PlayUnlockSequence()
		{
			AnniversaryActivityEnterItem.<PlayUnlockSequence>d__11 <PlayUnlockSequence>d__;
			<PlayUnlockSequence>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlayUnlockSequence>d__.<>4__this = this;
			<PlayUnlockSequence>d__.<>1__state = -1;
			<PlayUnlockSequence>d__.<>t__builder.Start<AnniversaryActivityEnterItem.<PlayUnlockSequence>d__11>(ref <PlayUnlockSequence>d__);
			return <PlayUnlockSequence>d__.<>t__builder.Task;
		}

		// Token: 0x06043303 RID: 275203 RVA: 0x01143EC0 File Offset: 0x011420C0
		private void SetLockState(bool isLock)
		{
			UUIItem item = base.GetItem(2);
			if (item != null)
			{
				item.SetUIActive(isLock);
			}
			UUIItem item2 = base.GetItem(10);
			if (item2 != null)
			{
				item2.SetUIActive(isLock);
			}
			UUIItem item3 = base.GetItem(11);
			if (item3 != null)
			{
				item3.SetUIActive(!isLock);
			}
			UUITexture texture = base.GetTexture(3);
			if (texture == null)
			{
				return;
			}
			texture.SetIsGray(isLock);
		}

		// Token: 0x06043304 RID: 275204 RVA: 0x01143F20 File Offset: 0x01142120
		public void RefreshRedDotItem()
		{
			AnniversarySubActivityDataBase data = this.Data;
			bool? flag;
			if (data == null)
			{
				flag = null;
			}
			else
			{
				ActivityBaseData activityData = data.GetActivityData();
				flag = ((activityData != null) ? new bool?(activityData.RedPointShowState) : null);
			}
			bool? flag2 = flag;
			bool valueOrDefault = flag2.GetValueOrDefault();
			UUIItem item = base.GetItem(13);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(valueOrDefault);
		}

		// Token: 0x06043305 RID: 275205 RVA: 0x01143F7C File Offset: 0x0114217C
		public void RefreshFinished()
		{
			AnniversarySubActivityDataBase data = this.Data;
			bool? flag;
			if (data == null)
			{
				flag = null;
			}
			else
			{
				ActivityBaseData activityData = data.GetActivityData();
				flag = ((activityData != null) ? new bool?(activityData.FinishShowState) : null);
			}
			bool? flag2 = flag;
			bool valueOrDefault = flag2.GetValueOrDefault();
			UUITexture texture = base.GetTexture(14);
			if (texture == null)
			{
				return;
			}
			texture.SetUIActive(valueOrDefault);
		}

		// Token: 0x06043306 RID: 275206 RVA: 0x01143FD8 File Offset: 0x011421D8
		public virtual void ChildUpdateStateInfo()
		{
		}

		// Token: 0x06043307 RID: 275207 RVA: 0x01143FDA File Offset: 0x011421DA
		public virtual void ChildUpdateTips()
		{
		}

		// Token: 0x0402570A RID: 153354
		protected AnniversarySubActivityDataBase Data;

		// Token: 0x0402570B RID: 153355
		private Action<int> ClickCallback;

		// Token: 0x0402570C RID: 153356
		public LevelSequencePlayer SequencePlayer;
	}
}
