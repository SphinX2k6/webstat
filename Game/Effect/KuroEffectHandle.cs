using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using UnrealEngine;

namespace CSharpScript.Game.Effect
{
	// Token: 0x0200704D RID: 28749
	[NullableContext(2)]
	[Nullable(0)]
	public class KuroEffectHandle
	{
		// Token: 0x1700A52B RID: 42283
		// (get) Token: 0x06045966 RID: 285030 RVA: 0x0122E56E File Offset: 0x0122C76E
		// (set) Token: 0x06045967 RID: 285031 RVA: 0x0122E576 File Offset: 0x0122C776
		public int Id { get; set; }

		// Token: 0x1700A52C RID: 42284
		// (get) Token: 0x06045968 RID: 285032 RVA: 0x0122E57F File Offset: 0x0122C77F
		// (set) Token: 0x06045969 RID: 285033 RVA: 0x0122E587 File Offset: 0x0122C787
		public bool IsLoop { get; set; }

		// Token: 0x0604596A RID: 285034 RVA: 0x0122E590 File Offset: 0x0122C790
		public void Init(EffectContext context, Action<int> beforeInitCallback = null, Action<ELoadEffectResult, int> callback = null, Action<int> beforePlayCallback = null)
		{
			this.Context = context;
			this.BeforeInitCallback = beforeInitCallback;
			this.EffectInitCallback = callback;
			this.BeforePlayCallback = beforePlayCallback;
		}

		// Token: 0x0604596B RID: 285035 RVA: 0x0122E5AF File Offset: 0x0122C7AF
		public void OnAfterSpawn(int effectId)
		{
			this.Id = effectId;
			this.IsLoop = UKuroEffectSystemFunctionLibrary.EffectIsLoop(effectId);
			this.RegisterFinishCallback();
		}

		// Token: 0x0604596C RID: 285036 RVA: 0x0122E5CA File Offset: 0x0122C7CA
		public void Clear(bool unbind = false)
		{
			this.UnregisterFinishCallback();
			if (unbind)
			{
				this.UnbindDelegates();
			}
			this.BeforeInitCallback = null;
			this.EffectInitCallback = null;
			this.BeforePlayCallback = null;
			this.DynamicEffectInitCallback = null;
			this.Context = null;
			this.OnCustomCheckOwner = null;
		}

		// Token: 0x0604596D RID: 285037 RVA: 0x0122E605 File Offset: 0x0122C805
		internal void OnSpawnDelegatesRegistered(FKuroEffectBeforeInitCallback beforeInitDelegate, FKuroEffectInitCallback initDelegate, FKuroEffectBeforePlayCallback beforePlayDelegate, FKuroEffectOnClearCallback clearDelegate)
		{
			this._beforeInitDelegate = beforeInitDelegate;
			this._initDelegate = initDelegate;
			this._beforePlayDelegate = beforePlayDelegate;
			this._clearDelegate = clearDelegate;
		}

		// Token: 0x0604596E RID: 285038 RVA: 0x0122E624 File Offset: 0x0122C824
		private void UnbindDelegates()
		{
			if (this._beforeInitDelegate != null)
			{
				global::DelegateUtils.ReleaseManualReleaseDelegate(new Action<int>(this.OnBeforeInitCallback));
				this._beforeInitDelegate = null;
			}
			if (this._initDelegate != null)
			{
				global::DelegateUtils.ReleaseManualReleaseDelegate(new Action<byte, int>(this.OnEffectInitCallback));
				this._initDelegate = null;
			}
			if (this._beforePlayDelegate != null)
			{
				global::DelegateUtils.ReleaseManualReleaseDelegate(new Action<int>(this.OnBeforePlayCallback));
				this._beforePlayDelegate = null;
			}
			if (this._clearDelegate != null)
			{
				global::DelegateUtils.ReleaseManualReleaseDelegate(new Action(this.OnInitCallbackClear));
				this._clearDelegate = null;
			}
			if (this._finishDelegate != null)
			{
				global::DelegateUtils.ReleaseManualReleaseDelegate(new Action<int>(this.OnEffectFinish));
				this._finishDelegate = null;
			}
			if (this._finishClearDelegate != null)
			{
				global::DelegateUtils.ReleaseManualReleaseDelegate(new Action(this.OnEffectFinishClear));
				this._finishClearDelegate = null;
			}
			if (this._dynamicInitDelegate != null)
			{
				global::DelegateUtils.ReleaseManualReleaseDelegate(new Action<byte, int>(this.OnDynamicEffectInitCallback));
				this._dynamicInitDelegate = null;
			}
			if (this._dynamicClearDelegate != null)
			{
				global::DelegateUtils.ReleaseManualReleaseDelegate(new Action(this.OnDynamicEffectInitCallbackClear));
				this._dynamicClearDelegate = null;
			}
		}

		// Token: 0x0604596F RID: 285039 RVA: 0x0122E734 File Offset: 0x0122C934
		public bool CheckOwner()
		{
			if (this.OnCustomCheckOwner != null)
			{
				return this.OnCustomCheckOwner(this.Id);
			}
			if (this.Context == null)
			{
				return true;
			}
			if (this.Context.EntityId != null)
			{
				int? entityId = this.Context.EntityId;
				int num = 0;
				if (!(entityId.GetValueOrDefault() == num & entityId != null))
				{
					Entity entity = Singleton<EntitySystem>.Instance.Get(this.Context.EntityId.Value);
					if (entity == null || !entity.Valid)
					{
						return false;
					}
				}
			}
			return this.Context.SourceObject == null || this.Context.SourceObject.IsValid();
		}

		// Token: 0x06045970 RID: 285040 RVA: 0x0122E7EE File Offset: 0x0122C9EE
		public bool IsDone()
		{
			return this.IsDoneInternal;
		}

		// Token: 0x06045971 RID: 285041 RVA: 0x0122E7F6 File Offset: 0x0122C9F6
		public void SetNotRecord(bool value)
		{
			this.NotRecordInternal = value;
		}

		// Token: 0x06045972 RID: 285042 RVA: 0x0122E7FF File Offset: 0x0122C9FF
		public bool GetNotRecord()
		{
			return this.NotRecordInternal;
		}

		// Token: 0x06045973 RID: 285043 RVA: 0x0122E808 File Offset: 0x0122CA08
		public void RegisterFinishCallback()
		{
			if (this.HasRegisterFinishCallback)
			{
				return;
			}
			this.HasRegisterFinishCallback = true;
			this._finishDelegate = global::DelegateUtils.ToManualReleaseDelegate<FKuroEffectFinishCallback>(new Action<int>(this.OnEffectFinish));
			this._finishClearDelegate = global::DelegateUtils.ToManualReleaseDelegate<FKuroEffectOnClearCallback>(new Action(this.OnEffectFinishClear));
			UKuroEffectSystemFunctionLibrary.AddFinishCallback(this.Id, this._finishDelegate, this._finishClearDelegate);
		}

		// Token: 0x06045974 RID: 285044 RVA: 0x0122E86A File Offset: 0x0122CA6A
		private void UnregisterFinishCallback()
		{
			if (!this.HasRegisterFinishCallback)
			{
				return;
			}
			this.HasRegisterFinishCallback = false;
			UKuroEffectSystemFunctionLibrary.RemoveFinishCallback(this.Id);
			HashSet<Action<int>> onFinishCallbackSet = this.OnFinishCallbackSet;
			if (onFinishCallbackSet == null)
			{
				return;
			}
			onFinishCallbackSet.Clear();
		}

		// Token: 0x06045975 RID: 285045 RVA: 0x0122E898 File Offset: 0x0122CA98
		private void OnEffectFinishClear()
		{
			if (this._finishDelegate != null)
			{
				global::DelegateUtils.ReleaseManualReleaseDelegate(new Action<int>(this.OnEffectFinish));
				this._finishDelegate = null;
			}
			if (this._finishClearDelegate != null)
			{
				global::DelegateUtils.ReleaseManualReleaseDelegate(new Action(this.OnEffectFinishClear));
				this._finishClearDelegate = null;
			}
			if (this.HasRegisterFinishCallback)
			{
				this.UnregisterFinishCallback();
			}
		}

		// Token: 0x06045976 RID: 285046 RVA: 0x0122E8F4 File Offset: 0x0122CAF4
		private void OnEffectFinish(int handle)
		{
			if (handle != this.Id && this.Id != 0)
			{
				return;
			}
			if (this.OnFinishCallbackSet != null)
			{
				Action<int>[] array = this.OnFinishCallbackSet.ToArray<Action<int>>();
				for (int i = 0; i < array.Length; i++)
				{
					array[i](handle);
				}
			}
			Singleton<EventSystem>.Instance.Emit<int, string, bool>(EEventName.FinishEffect, this.Id, "KuroEffectHandle.OnAfterFinish", true);
			Singleton<EffectSystem>.Instance.RemoveKuroEffectHandle(this.Id);
		}

		// Token: 0x06045977 RID: 285047 RVA: 0x0122E96A File Offset: 0x0122CB6A
		[NullableContext(1)]
		public void AddFinishCallback(Action<int> callback)
		{
			if (callback == null)
			{
				return;
			}
			if (this.OnFinishCallbackSet == null)
			{
				this.OnFinishCallbackSet = new HashSet<Action<int>>();
			}
			if (!this.OnFinishCallbackSet.Contains(callback))
			{
				this.OnFinishCallbackSet.Add(callback);
			}
		}

		// Token: 0x06045978 RID: 285048 RVA: 0x0122E99E File Offset: 0x0122CB9E
		[NullableContext(1)]
		public bool RemoveFinishCallback(Action<int> callback)
		{
			return this.OnFinishCallbackSet != null && this.OnFinishCallbackSet.Remove(callback);
		}

		// Token: 0x06045979 RID: 285049 RVA: 0x0122E9B6 File Offset: 0x0122CBB6
		public void OnBeforeInitCallback(int handle)
		{
			if (handle != this.Id && this.Id != 0)
			{
				return;
			}
			Action<int> beforeInitCallback = this.BeforeInitCallback;
			if (beforeInitCallback == null)
			{
				return;
			}
			beforeInitCallback(handle);
		}

		// Token: 0x0604597A RID: 285050 RVA: 0x0122E9DB File Offset: 0x0122CBDB
		public void OnEffectInitCallback(byte result, int handle)
		{
			if (handle != this.Id && this.Id != 0)
			{
				return;
			}
			Action<ELoadEffectResult, int> effectInitCallback = this.EffectInitCallback;
			if (effectInitCallback == null)
			{
				return;
			}
			effectInitCallback((ELoadEffectResult)result, handle);
		}

		// Token: 0x0604597B RID: 285051 RVA: 0x0122EA04 File Offset: 0x0122CC04
		public void OnBeforePlayCallback(int handle)
		{
			if (handle != this.Id && this.Id != 0)
			{
				return;
			}
			this.IsDoneInternal = true;
			Action<int> beforePlayCallback = this.BeforePlayCallback;
			if (beforePlayCallback != null)
			{
				beforePlayCallback(handle);
			}
			Singleton<EventSystem>.Instance.Emit<int, string>(EEventName.BeforePlayEffect, this.Id, "KuroEffectHandle.OnBeforePlay");
		}

		// Token: 0x0604597C RID: 285052 RVA: 0x0122EA58 File Offset: 0x0122CC58
		public void OnInitCallbackClear()
		{
			if (this._beforeInitDelegate != null)
			{
				global::DelegateUtils.ReleaseManualReleaseDelegate(new Action<int>(this.OnBeforeInitCallback));
				this._beforeInitDelegate = null;
			}
			if (this._initDelegate != null)
			{
				global::DelegateUtils.ReleaseManualReleaseDelegate(new Action<byte, int>(this.OnEffectInitCallback));
				this._initDelegate = null;
			}
			if (this._beforePlayDelegate != null)
			{
				global::DelegateUtils.ReleaseManualReleaseDelegate(new Action<int>(this.OnBeforePlayCallback));
				this._beforePlayDelegate = null;
			}
			if (this._clearDelegate != null)
			{
				global::DelegateUtils.ReleaseManualReleaseDelegate(new Action(this.OnInitCallbackClear));
				this._clearDelegate = null;
			}
			this.BeforeInitCallback = null;
			this.EffectInitCallback = null;
			this.BeforePlayCallback = null;
		}

		// Token: 0x0604597D RID: 285053 RVA: 0x0122EAFC File Offset: 0x0122CCFC
		[NullableContext(1)]
		public void RegisterDynamicEffectInitCallback(Action<ELoadEffectResult, int> callback)
		{
			if (this._dynamicInitDelegate != null)
			{
				global::DelegateUtils.ReleaseManualReleaseDelegate(new Action<byte, int>(this.OnDynamicEffectInitCallback));
				global::DelegateUtils.ReleaseManualReleaseDelegate(new Action(this.OnDynamicEffectInitCallbackClear));
				this._dynamicInitDelegate = null;
				this._dynamicClearDelegate = null;
			}
			this.DynamicEffectInitCallback = callback;
			this._dynamicInitDelegate = global::DelegateUtils.ToManualReleaseDelegate<FKuroEffectInitCallback>(new Action<byte, int>(this.OnDynamicEffectInitCallback));
			this._dynamicClearDelegate = global::DelegateUtils.ToManualReleaseDelegate<FKuroEffectOnClearCallback>(new Action(this.OnDynamicEffectInitCallbackClear));
			UKuroEffectSystemFunctionLibrary.DynamicRegisterSpawnCallback(this.Id, this._dynamicInitDelegate, this._dynamicClearDelegate);
		}

		// Token: 0x0604597E RID: 285054 RVA: 0x0122EB8D File Offset: 0x0122CD8D
		private void OnDynamicEffectInitCallback(byte result, int handle)
		{
			if (handle != this.Id && this.Id != 0)
			{
				return;
			}
			Action<ELoadEffectResult, int> dynamicEffectInitCallback = this.DynamicEffectInitCallback;
			if (dynamicEffectInitCallback == null)
			{
				return;
			}
			dynamicEffectInitCallback((ELoadEffectResult)result, handle);
		}

		// Token: 0x0604597F RID: 285055 RVA: 0x0122EBB4 File Offset: 0x0122CDB4
		private void OnDynamicEffectInitCallbackClear()
		{
			if (this._dynamicInitDelegate != null)
			{
				global::DelegateUtils.ReleaseManualReleaseDelegate(new Action<byte, int>(this.OnDynamicEffectInitCallback));
				this._dynamicInitDelegate = null;
			}
			if (this._dynamicClearDelegate != null)
			{
				global::DelegateUtils.ReleaseManualReleaseDelegate(new Action(this.OnDynamicEffectInitCallbackClear));
				this._dynamicClearDelegate = null;
			}
			this.DynamicEffectInitCallback = null;
		}

		// Token: 0x04026D85 RID: 159109
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private HashSet<Action<int>> OnFinishCallbackSet;

		// Token: 0x04026D86 RID: 159110
		private Action<int> BeforeInitCallback;

		// Token: 0x04026D87 RID: 159111
		private Action<ELoadEffectResult, int> EffectInitCallback;

		// Token: 0x04026D88 RID: 159112
		private Action<int> BeforePlayCallback;

		// Token: 0x04026D89 RID: 159113
		private Action<ELoadEffectResult, int> DynamicEffectInitCallback;

		// Token: 0x04026D8A RID: 159114
		private EffectContext Context;

		// Token: 0x04026D8B RID: 159115
		public Func<int, bool> OnCustomCheckOwner;

		// Token: 0x04026D8C RID: 159116
		private FKuroEffectBeforeInitCallback _beforeInitDelegate;

		// Token: 0x04026D8D RID: 159117
		private FKuroEffectInitCallback _initDelegate;

		// Token: 0x04026D8E RID: 159118
		private FKuroEffectBeforePlayCallback _beforePlayDelegate;

		// Token: 0x04026D8F RID: 159119
		private FKuroEffectOnClearCallback _clearDelegate;

		// Token: 0x04026D90 RID: 159120
		private FKuroEffectFinishCallback _finishDelegate;

		// Token: 0x04026D91 RID: 159121
		private FKuroEffectOnClearCallback _finishClearDelegate;

		// Token: 0x04026D92 RID: 159122
		private FKuroEffectInitCallback _dynamicInitDelegate;

		// Token: 0x04026D93 RID: 159123
		private FKuroEffectOnClearCallback _dynamicClearDelegate;

		// Token: 0x04026D94 RID: 159124
		private bool IsDoneInternal;

		// Token: 0x04026D95 RID: 159125
		private bool NotRecordInternal;

		// Token: 0x04026D96 RID: 159126
		private bool HasRegisterFinishCallback;
	}
}
