using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Render.RuntimeBP.ScreenEffect;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Render.Effect.ScreenEffectSystem;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02006015 RID: 24597
	[NullableContext(1)]
	[Nullable(0)]
	public class FullScreenPanel : BattleChildViewPanel
	{
		// Token: 0x0603DFAB RID: 253867 RVA: 0x00FD0D2B File Offset: 0x00FCEF2B
		public override void InitializeTemp()
		{
			this.AddScreenEffectFightRoot();
		}

		// Token: 0x0603DFAC RID: 253868 RVA: 0x00FD0D33 File Offset: 0x00FCEF33
		public override void Reset()
		{
			this.ClearFullScreenNiagaraItem();
			this.RemoveScreenEffectFightRoot();
			base.Reset();
		}

		// Token: 0x0603DFAD RID: 253869 RVA: 0x00FD0D48 File Offset: 0x00FCEF48
		protected override void AddEvents()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.OnAddFullScreenEffect, new Action<FullScreenEffectHandle>(this.OnAddFullScreenEffect));
			Singleton<EventSystem>.Instance.Add(EEventName.OnRemoveFullScreenEffect, new Action<FullScreenEffectHandle>(this.OnRemoveFullScreenEffect));
			Singleton<EventSystem>.Instance.Add(EEventName.OnClearFullScreenEffect, new Action(this.OnClearFullScreenEffect));
			Singleton<EventSystem>.Instance.Add(EEventName.OnChangeFullScreenNiagaraFloatParameter, new Action<long, string, float>(this.OnChangeFullScreenNiagaraFloatParameter));
		}

		// Token: 0x0603DFAE RID: 253870 RVA: 0x00FD0DC8 File Offset: 0x00FCEFC8
		protected override void RemoveEvents()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnAddFullScreenEffect, new Action<FullScreenEffectHandle>(this.OnAddFullScreenEffect));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnRemoveFullScreenEffect, new Action<FullScreenEffectHandle>(this.OnRemoveFullScreenEffect));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnClearFullScreenEffect, new Action(this.OnClearFullScreenEffect));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnChangeFullScreenNiagaraFloatParameter, new Action<long, string, float>(this.OnChangeFullScreenNiagaraFloatParameter));
		}

		// Token: 0x0603DFAF RID: 253871 RVA: 0x00FD0E48 File Offset: 0x00FCF048
		private void OnAddFullScreenEffect(FullScreenEffectHandle fullScreenEffectHandle)
		{
			long uniqueId = fullScreenEffectHandle.UniqueId;
			string niagaraPath = fullScreenEffectHandle.NiagaraPath;
			this.AddFullScreenNiagaraItem(uniqueId, niagaraPath).ContinueWith(delegate(FullScreenNiagaraItem fullScreenNiagaraItem)
			{
				if (fullScreenNiagaraItem == null)
				{
					return;
				}
				foreach (KeyValuePair<string, float> keyValuePair in fullScreenEffectHandle.GetFloatParameterMap())
				{
					string text;
					float num;
					keyValuePair.Deconstruct(out text, out num);
					string key = text;
					float value = num;
					fullScreenNiagaraItem.SetNiagaraFloatValue(key, value);
				}
			});
		}

		// Token: 0x0603DFB0 RID: 253872 RVA: 0x00FD0E94 File Offset: 0x00FCF094
		private void OnRemoveFullScreenEffect(FullScreenEffectHandle fullScreenEffectHandle)
		{
			long uniqueId = fullScreenEffectHandle.UniqueId;
			this.RemovePendingDisplay(uniqueId);
			this.RemoveFullScreenNiagaraItem(uniqueId);
		}

		// Token: 0x0603DFB1 RID: 253873 RVA: 0x00FD0EB7 File Offset: 0x00FCF0B7
		private void OnClearFullScreenEffect()
		{
			this.ClearFullScreenNiagaraItem();
		}

		// Token: 0x0603DFB2 RID: 253874 RVA: 0x00FD0EC0 File Offset: 0x00FCF0C0
		private void OnChangeFullScreenNiagaraFloatParameter(long uniqueId, string key, float value)
		{
			FullScreenNiagaraItem fullScreenNiagaraItem = this.GetFullScreenNiagaraItem(uniqueId);
			if (fullScreenNiagaraItem == null)
			{
				return;
			}
			fullScreenNiagaraItem.SetNiagaraFloatValue(key, value);
		}

		// Token: 0x0603DFB3 RID: 253875 RVA: 0x00FD0EE1 File Offset: 0x00FCF0E1
		private void AddPendingDisplay(long uniqueId)
		{
			this.PendingDisplayUniqueIdSet.Add(uniqueId);
		}

		// Token: 0x0603DFB4 RID: 253876 RVA: 0x00FD0EF0 File Offset: 0x00FCF0F0
		private void RemovePendingDisplay(long uniqueId)
		{
			this.PendingDisplayUniqueIdSet.Remove(uniqueId);
		}

		// Token: 0x0603DFB5 RID: 253877 RVA: 0x00FD0EFF File Offset: 0x00FCF0FF
		private bool IsPendingDisplay(long uniqueId)
		{
			return this.PendingDisplayUniqueIdSet.Contains(uniqueId);
		}

		// Token: 0x0603DFB6 RID: 253878 RVA: 0x00FD0F10 File Offset: 0x00FCF110
		[return: Nullable(new byte[]
		{
			0,
			2
		})]
		private UniTask<FullScreenNiagaraItem> AddFullScreenNiagaraItem(long uniqueId, string niagaraPath)
		{
			FullScreenPanel.<AddFullScreenNiagaraItem>d__14 <AddFullScreenNiagaraItem>d__;
			<AddFullScreenNiagaraItem>d__.<>t__builder = AsyncUniTaskMethodBuilder<FullScreenNiagaraItem>.Create();
			<AddFullScreenNiagaraItem>d__.<>4__this = this;
			<AddFullScreenNiagaraItem>d__.uniqueId = uniqueId;
			<AddFullScreenNiagaraItem>d__.niagaraPath = niagaraPath;
			<AddFullScreenNiagaraItem>d__.<>1__state = -1;
			<AddFullScreenNiagaraItem>d__.<>t__builder.Start<FullScreenPanel.<AddFullScreenNiagaraItem>d__14>(ref <AddFullScreenNiagaraItem>d__);
			return <AddFullScreenNiagaraItem>d__.<>t__builder.Task;
		}

		// Token: 0x0603DFB7 RID: 253879 RVA: 0x00FD0F64 File Offset: 0x00FCF164
		private bool RemoveFullScreenNiagaraItem(long uniqueId)
		{
			FullScreenNiagaraItem fullScreenNiagaraItem = this.GetFullScreenNiagaraItem(uniqueId);
			if (fullScreenNiagaraItem == null)
			{
				return false;
			}
			fullScreenNiagaraItem.Destroy(null);
			this.FullScreenNiagaraItemMap.Remove(uniqueId);
			return true;
		}

		// Token: 0x0603DFB8 RID: 253880 RVA: 0x00FD0F94 File Offset: 0x00FCF194
		[return: Nullable(new byte[]
		{
			0,
			1
		})]
		private UniTask<FullScreenNiagaraItem> NewFullScreenNiagaraItem(long cueId)
		{
			FullScreenPanel.<NewFullScreenNiagaraItem>d__16 <NewFullScreenNiagaraItem>d__;
			<NewFullScreenNiagaraItem>d__.<>t__builder = AsyncUniTaskMethodBuilder<FullScreenNiagaraItem>.Create();
			<NewFullScreenNiagaraItem>d__.<>4__this = this;
			<NewFullScreenNiagaraItem>d__.<>1__state = -1;
			<NewFullScreenNiagaraItem>d__.<>t__builder.Start<FullScreenPanel.<NewFullScreenNiagaraItem>d__16>(ref <NewFullScreenNiagaraItem>d__);
			return <NewFullScreenNiagaraItem>d__.<>t__builder.Task;
		}

		// Token: 0x0603DFB9 RID: 253881 RVA: 0x00FD0FD7 File Offset: 0x00FCF1D7
		[NullableContext(2)]
		private FullScreenNiagaraItem GetFullScreenNiagaraItem(long cueId)
		{
			return this.FullScreenNiagaraItemMap.GetValueOrDefault(cueId);
		}

		// Token: 0x0603DFBA RID: 253882 RVA: 0x00FD0FE8 File Offset: 0x00FCF1E8
		private void ClearFullScreenNiagaraItem()
		{
			if (this.FullScreenNiagaraItemMap.Count <= 0)
			{
				return;
			}
			foreach (FullScreenNiagaraItem fullScreenNiagaraItem in this.FullScreenNiagaraItemMap.Values)
			{
				fullScreenNiagaraItem.Reset();
			}
			this.FullScreenNiagaraItemMap.Clear();
			this.PendingDisplayUniqueIdSet.Clear();
		}

		// Token: 0x0603DFBB RID: 253883 RVA: 0x00FD1064 File Offset: 0x00FCF264
		private void AddScreenEffectFightRoot()
		{
			BP_ScreenEffectSystem_C instance = ScreenEffectSystem.GetInstance();
			if (!instance.IsValid())
			{
				return;
			}
			instance.GetScreenEffectFightRoot(ref this.ScreenEffectFightRoot);
			AUIContainerActor screenEffectFightRoot = this.ScreenEffectFightRoot;
			if (screenEffectFightRoot != null)
			{
				screenEffectFightRoot.K2_AttachRootComponentTo(this.RootItem, default(FName), EAttachLocation.KeepRelativeOffset, true);
			}
			ModelBase<ScreenEffectModel>.Instance.SetFightRootInited(true);
		}

		// Token: 0x0603DFBC RID: 253884 RVA: 0x00FD10B9 File Offset: 0x00FCF2B9
		private void RemoveScreenEffectFightRoot()
		{
			AUIContainerActor screenEffectFightRoot = this.ScreenEffectFightRoot;
			if (screenEffectFightRoot != null && screenEffectFightRoot.IsValid())
			{
				this.ScreenEffectFightRoot.K2_DetachFromActor(EDetachmentRule.KeepRelative, EDetachmentRule.KeepRelative, EDetachmentRule.KeepRelative);
			}
			this.ScreenEffectFightRoot = null;
			ModelBase<ScreenEffectModel>.Instance.SetFightRootInited(false);
		}

		// Token: 0x04022C2C RID: 142380
		private readonly Dictionary<long, FullScreenNiagaraItem> FullScreenNiagaraItemMap = new Dictionary<long, FullScreenNiagaraItem>();

		// Token: 0x04022C2D RID: 142381
		private readonly HashSet<long> PendingDisplayUniqueIdSet = new HashSet<long>();

		// Token: 0x04022C2E RID: 142382
		[Nullable(2)]
		private AUIContainerActor ScreenEffectFightRoot;
	}
}
