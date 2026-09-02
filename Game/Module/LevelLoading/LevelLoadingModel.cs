using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;

namespace CSharpScript.Game.Module.LevelLoading
{
	// Token: 0x02005A19 RID: 23065
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Model(0)]
	public class LevelLoadingModel : ModelBase<LevelLoadingModel>
	{
		// Token: 0x170094CB RID: 38091
		// (get) Token: 0x0603A653 RID: 239187 RVA: 0x00ECECD8 File Offset: 0x00ECCED8
		public bool IsLoading
		{
			get
			{
				return this.IsLoadingInternal;
			}
		}

		// Token: 0x0603A654 RID: 239188 RVA: 0x00ECECE0 File Offset: 0x00ECCEE0
		protected override bool OnClear()
		{
			this.OpenLoadingReason.Clear();
			this.LoadingPerforms.Clear();
			return true;
		}

		// Token: 0x0603A655 RID: 239189 RVA: 0x00ECECFC File Offset: 0x00ECCEFC
		public void SetLoadingState(bool value)
		{
			if (this.IsLoadingInternal == value)
			{
				return;
			}
			this.IsLoadingInternal = value;
			if (!value)
			{
				this.ClearLoadingReason();
				this.ClearLoadingPerforms();
				Singleton<Log>.Instance.Info(ELogModule.Loading, ELogAuthor.YZH, "LevelLoading:LoadingModeDisable", default(ReadOnlySpan<ValueTuple<string, object>>));
				if (Singleton<LoadModeManager>.Instance.IsReasonTargetNotDefault(ELoadModeReason.LevelLoading))
				{
					Singleton<LoadModeManager>.Instance.ResetLoadModeByReason(ELoadModeReason.LevelLoading);
				}
				Singleton<EventSystem>.Instance.Emit(EEventName.RemoveLevelLoadingTimeDilationTag);
				return;
			}
			Singleton<Log>.Instance.Info(ELogModule.Loading, ELogAuthor.YZH, "LevelLoading:LoadingModeEnable", default(ReadOnlySpan<ValueTuple<string, object>>));
			Singleton<LoadModeManager>.Instance.SetLoadModeByReason(ELoadMode.Loading, ELoadModeReason.LevelLoading);
			Singleton<EventSystem>.Instance.Emit(EEventName.AddLevelLoadingTimeDilationTag);
		}

		// Token: 0x0603A656 RID: 239190 RVA: 0x00ECEDA4 File Offset: 0x00ECCFA4
		public void AddLoadingReason(ELoadingReason reason, ELoadingPerform perform)
		{
			this.OpenLoadingReason[reason] = perform;
			this.AddLoadingPerform(perform);
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Loading;
			ELogAuthor author = ELogAuthor.YSQ;
			string message = "LevelLoading:AddLoadingReason";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("reason", reason);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}

		// Token: 0x0603A657 RID: 239191 RVA: 0x00ECEDF4 File Offset: 0x00ECCFF4
		public void RemoveLoadingReason(ELoadingReason reason)
		{
			ELoadingPerform? performByReason = this.GetPerformByReason(reason);
			this.OpenLoadingReason.Remove(reason);
			this.RemoveLoadingPerform(performByReason);
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Loading;
			ELogAuthor author = ELogAuthor.YSQ;
			string message = "LevelLoading:RemoveLoadingReason";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("reason", reason);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}

		// Token: 0x0603A658 RID: 239192 RVA: 0x00ECEE4C File Offset: 0x00ECD04C
		public unsafe void AddLoadingPerform(ELoadingPerform perform)
		{
			int valueOrDefault = this.LoadingPerforms.GetValueOrDefault(perform, 0);
			this.LoadingPerforms[perform] = valueOrDefault + 1;
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Loading;
			ELogAuthor author = ELogAuthor.YSQ;
			string message = "LevelLoading:AddLoadingPerform";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("perform", perform);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("count", valueOrDefault + 1);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		}

		// Token: 0x0603A659 RID: 239193 RVA: 0x00ECEED8 File Offset: 0x00ECD0D8
		public void RemoveLoadingPerform(ELoadingPerform? perform)
		{
			if (perform == null)
			{
				return;
			}
			int num;
			if (!this.LoadingPerforms.TryGetValue(perform.Value, out num))
			{
				return;
			}
			int num2 = num - 1;
			this.LoadingPerforms[perform.Value] = num2;
			if (num2 <= 0)
			{
				this.LoadingPerforms.Remove(perform.Value);
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Loading;
				ELogAuthor author = ELogAuthor.YSQ;
				string message = "LevelLoading:RemoveLoadingPerform";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("perform", perform);
				instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
		}

		// Token: 0x0603A65A RID: 239194 RVA: 0x00ECEF60 File Offset: 0x00ECD160
		public ELoadingPerform? GetPerformByReason(ELoadingReason reason)
		{
			ELoadingPerform value;
			if (!this.OpenLoadingReason.TryGetValue(reason, out value))
			{
				return null;
			}
			return new ELoadingPerform?(value);
		}

		// Token: 0x0603A65B RID: 239195 RVA: 0x00ECEF90 File Offset: 0x00ECD190
		public List<ELoadingReason> GetReasonsByPerform(ELoadingPerform targetPerform)
		{
			List<ELoadingReason> list = new List<ELoadingReason>();
			foreach (KeyValuePair<ELoadingReason, ELoadingPerform> keyValuePair in this.OpenLoadingReason)
			{
				ELoadingReason eloadingReason;
				ELoadingPerform eloadingPerform;
				keyValuePair.Deconstruct(out eloadingReason, out eloadingPerform);
				ELoadingReason item = eloadingReason;
				ELoadingPerform eloadingPerform2 = eloadingPerform;
				if (targetPerform == eloadingPerform2)
				{
					list.Add(item);
				}
			}
			return list;
		}

		// Token: 0x0603A65C RID: 239196 RVA: 0x00ECF000 File Offset: 0x00ECD200
		private void ClearLoadingReason()
		{
			this.OpenLoadingReason.Clear();
			Singleton<Log>.Instance.Info(ELogModule.Loading, ELogAuthor.YSQ, "LevelLoading:ClearLoadingReason", default(ReadOnlySpan<ValueTuple<string, object>>));
		}

		// Token: 0x0603A65D RID: 239197 RVA: 0x00ECF034 File Offset: 0x00ECD234
		public void ClearLoadingPerforms()
		{
			this.LoadingPerforms.Clear();
			Singleton<Log>.Instance.Info(ELogModule.Loading, ELogAuthor.YSQ, "LevelLoading:ClearLoadingPerforms", default(ReadOnlySpan<ValueTuple<string, object>>));
		}

		// Token: 0x0603A65E RID: 239198 RVA: 0x00ECF068 File Offset: 0x00ECD268
		public bool CheckLoadingPerformsEmpty()
		{
			return this.LoadingPerforms.Count == 0;
		}

		// Token: 0x0603A65F RID: 239199 RVA: 0x00ECF078 File Offset: 0x00ECD278
		public bool CheckLoadingPerformExist(ELoadingPerform? perform)
		{
			int num;
			return this.IsLoading && perform != null && (this.LoadingPerforms.TryGetValue(perform.Value, out num) && num > 0);
		}

		// Token: 0x0603A660 RID: 239200 RVA: 0x00ECF0B7 File Offset: 0x00ECD2B7
		public void FinishCameraShowPromise()
		{
			CustomPromise cameraFadeShowPromise = this.CameraFadeShowPromise;
			if (cameraFadeShowPromise != null)
			{
				cameraFadeShowPromise.SetResult();
			}
			this.CameraFadeShowPromise = null;
		}

		// Token: 0x0603A661 RID: 239201 RVA: 0x00ECF0D1 File Offset: 0x00ECD2D1
		public void FinishCameraHidePromise()
		{
			CustomPromise cameraFadeHidePromise = this.CameraFadeHidePromise;
			if (cameraFadeHidePromise != null)
			{
				cameraFadeHidePromise.SetResult();
			}
			this.CameraFadeHidePromise = null;
		}

		// Token: 0x04021139 RID: 135481
		[Nullable(2)]
		public CustomPromise CameraFadeShowPromise;

		// Token: 0x0402113A RID: 135482
		[Nullable(2)]
		public CustomPromise CameraFadeHidePromise;

		// Token: 0x0402113B RID: 135483
		private readonly Dictionary<ELoadingReason, ELoadingPerform> OpenLoadingReason = new Dictionary<ELoadingReason, ELoadingPerform>();

		// Token: 0x0402113C RID: 135484
		private readonly Dictionary<ELoadingPerform, int> LoadingPerforms = new Dictionary<ELoadingPerform, int>();

		// Token: 0x0402113D RID: 135485
		private bool IsLoadingInternal;
	}
}
