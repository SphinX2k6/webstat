using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using AkiClient.Game.Aki.Core;
using UnrealEngine;
using UnrealEngine.Extension;

namespace CSharpScript.Game.Module.Season
{
	// Token: 0x02004FFD RID: 20477
	[NullableContext(2)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Model(0)]
	public class SeasonModel : ModelBase<SeasonModel>
	{
		// Token: 0x17008AAF RID: 35503
		// (get) Token: 0x06034C7D RID: 216189 RVA: 0x00D3E7F3 File Offset: 0x00D3C9F3
		public bool IsMaterialReady
		{
			get
			{
				UMaterialParameterCollection materialAssetInternal = this.MaterialAssetInternal;
				return materialAssetInternal != null && materialAssetInternal.IsValid();
			}
		}

		// Token: 0x17008AB0 RID: 35504
		// (get) Token: 0x06034C7E RID: 216190 RVA: 0x00D3E806 File Offset: 0x00D3CA06
		public UMaterialParameterCollection MaterialAsset
		{
			get
			{
				return this.MaterialAssetInternal;
			}
		}

		// Token: 0x17008AB1 RID: 35505
		// (get) Token: 0x06034C7F RID: 216191 RVA: 0x00D3E80E File Offset: 0x00D3CA0E
		// (set) Token: 0x06034C80 RID: 216192 RVA: 0x00D3E816 File Offset: 0x00D3CA16
		public FName? TimelineParamName { get; private set; }

		// Token: 0x17008AB2 RID: 35506
		// (get) Token: 0x06034C81 RID: 216193 RVA: 0x00D3E81F File Offset: 0x00D3CA1F
		// (set) Token: 0x06034C82 RID: 216194 RVA: 0x00D3E827 File Offset: 0x00D3CA27
		public double CurrentValue { get; set; }

		// Token: 0x17008AB3 RID: 35507
		// (get) Token: 0x06034C83 RID: 216195 RVA: 0x00D3E830 File Offset: 0x00D3CA30
		// (set) Token: 0x06034C84 RID: 216196 RVA: 0x00D3E838 File Offset: 0x00D3CA38
		public double? LastWrittenValue { get; set; }

		// Token: 0x17008AB4 RID: 35508
		// (get) Token: 0x06034C85 RID: 216197 RVA: 0x00D3E841 File Offset: 0x00D3CA41
		// (set) Token: 0x06034C86 RID: 216198 RVA: 0x00D3E849 File Offset: 0x00D3CA49
		public ESeason? LastReportedSeason { get; set; }

		// Token: 0x17008AB5 RID: 35509
		// (get) Token: 0x06034C87 RID: 216199 RVA: 0x00D3E852 File Offset: 0x00D3CA52
		// (set) Token: 0x06034C88 RID: 216200 RVA: 0x00D3E85A File Offset: 0x00D3CA5A
		public ESeasonDriverPhase DriverPhase { get; set; }

		// Token: 0x17008AB6 RID: 35510
		// (get) Token: 0x06034C89 RID: 216201 RVA: 0x00D3E863 File Offset: 0x00D3CA63
		// (set) Token: 0x06034C8A RID: 216202 RVA: 0x00D3E86C File Offset: 0x00D3CA6C
		public ILoopSeasonChange LoopConfig
		{
			get
			{
				return this.LoopConfigInternal;
			}
			set
			{
				this.LoopConfigInternal = value;
				if (value != null)
				{
					this.LoopConfigByIndex = new ISeasonLoopConfig[]
					{
						value.SpringConfig,
						value.SummerConfig,
						value.AutumnConfig,
						value.WinterConfig
					};
					return;
				}
				this.LoopConfigByIndex = null;
			}
		}

		// Token: 0x17008AB7 RID: 35511
		// (get) Token: 0x06034C8B RID: 216203 RVA: 0x00D3E8BD File Offset: 0x00D3CABD
		// (set) Token: 0x06034C8C RID: 216204 RVA: 0x00D3E8C5 File Offset: 0x00D3CAC5
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public IReadOnlyList<ISeasonLoopConfig> LoopConfigByIndex { [return: Nullable(new byte[]
		{
			2,
			1
		})] get; [param: Nullable(new byte[]
		{
			2,
			1
		})] private set; }

		// Token: 0x17008AB8 RID: 35512
		// (get) Token: 0x06034C8D RID: 216205 RVA: 0x00D3E8CE File Offset: 0x00D3CACE
		// (set) Token: 0x06034C8E RID: 216206 RVA: 0x00D3E8D6 File Offset: 0x00D3CAD6
		public ISeasonLoopState LoopState { get; set; }

		// Token: 0x17008AB9 RID: 35513
		// (get) Token: 0x06034C8F RID: 216207 RVA: 0x00D3E8DF File Offset: 0x00D3CADF
		[Nullable(1)]
		public List<ISeasonSwitchJob> SwitchQueue { [NullableContext(1)] get; } = new List<ISeasonSwitchJob>();

		// Token: 0x17008ABA RID: 35514
		// (get) Token: 0x06034C90 RID: 216208 RVA: 0x00D3E8E7 File Offset: 0x00D3CAE7
		[Nullable(1)]
		public HashSet<int> ActiveAreaIds { [NullableContext(1)] get; } = new HashSet<int>();

		// Token: 0x06034C91 RID: 216209 RVA: 0x00D3E8F0 File Offset: 0x00D3CAF0
		[NullableContext(1)]
		public void RegisterVolume(TsTriggerVolume volume)
		{
			int seasonAreaId = volume.SeasonAreaId;
			if (seasonAreaId == 0)
			{
				return;
			}
			TsTriggerVolume tsTriggerVolume;
			if (this.RegisteredVolumesByAreaIdInternal.TryGetValue(seasonAreaId, out tsTriggerVolume) && tsTriggerVolume != volume)
			{
				global::Log instance = Singleton<global::Log>.Instance;
				ELogModule module = ELogModule.Season;
				ELogAuthor author = ELogAuthor.YSQ;
				string message = "同一 SeasonAreaId 配到多个 volume";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("areaId", seasonAreaId);
				instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			this.RegisteredVolumesByAreaIdInternal[seasonAreaId] = volume;
		}

		// Token: 0x06034C92 RID: 216210 RVA: 0x00D3E958 File Offset: 0x00D3CB58
		[NullableContext(1)]
		public void UnregisterVolume(TsTriggerVolume volume)
		{
			int seasonAreaId = volume.SeasonAreaId;
			if (seasonAreaId == 0)
			{
				return;
			}
			TsTriggerVolume tsTriggerVolume;
			if (this.RegisteredVolumesByAreaIdInternal.TryGetValue(seasonAreaId, out tsTriggerVolume) && tsTriggerVolume == volume)
			{
				this.RegisteredVolumesByAreaIdInternal.Remove(seasonAreaId);
			}
		}

		// Token: 0x06034C93 RID: 216211 RVA: 0x00D3E991 File Offset: 0x00D3CB91
		public bool IsAreaActive(int areaId)
		{
			return this.ActiveAreaIds.Contains(areaId);
		}

		// Token: 0x06034C94 RID: 216212 RVA: 0x00D3E99F File Offset: 0x00D3CB9F
		public void ActivateArea(int areaId)
		{
			if (areaId == 0)
			{
				return;
			}
			this.ActiveAreaIds.Add(areaId);
		}

		// Token: 0x06034C95 RID: 216213 RVA: 0x00D3E9B2 File Offset: 0x00D3CBB2
		public void DeactivateArea(int areaId)
		{
			if (areaId == 0)
			{
				return;
			}
			this.ActiveAreaIds.Remove(areaId);
		}

		// Token: 0x06034C96 RID: 216214 RVA: 0x00D3E9C5 File Offset: 0x00D3CBC5
		public void MarkPlayerInside(int areaId)
		{
			if (areaId == 0)
			{
				return;
			}
			this.PlayerInsideAreaIdsInternal.Add(areaId);
		}

		// Token: 0x06034C97 RID: 216215 RVA: 0x00D3E9D8 File Offset: 0x00D3CBD8
		public void MarkPlayerOutside(int areaId)
		{
			if (areaId == 0)
			{
				return;
			}
			this.PlayerInsideAreaIdsInternal.Remove(areaId);
		}

		// Token: 0x06034C98 RID: 216216 RVA: 0x00D3E9EB File Offset: 0x00D3CBEB
		public bool IsPlayerInside(int areaId)
		{
			return this.PlayerInsideAreaIdsInternal.Contains(areaId);
		}

		// Token: 0x06034C99 RID: 216217 RVA: 0x00D3E9FC File Offset: 0x00D3CBFC
		[NullableContext(1)]
		public void PushSwitchJob(ISwitchSeason job, double targetValue, double forwardDistance, [Nullable(2)] TSeasonSwitchCallback onComplete = null)
		{
			this.SwitchQueue.Add(new SeasonSwitchJob
			{
				TargetSeason = job.Season,
				TargetValue = targetValue,
				Speed = (double)job.TransitionSpeed,
				RemainDistance = forwardDistance,
				OnComplete = onComplete
			});
		}

		// Token: 0x06034C9A RID: 216218 RVA: 0x00D3EA48 File Offset: 0x00D3CC48
		public ISeasonSwitchJob PeekSwitchHead()
		{
			if (this.SwitchQueue.Count <= 0)
			{
				return null;
			}
			return this.SwitchQueue[0];
		}

		// Token: 0x06034C9B RID: 216219 RVA: 0x00D3EA66 File Offset: 0x00D3CC66
		public ISeasonSwitchJob PopSwitchHead()
		{
			if (this.SwitchQueue.Count > 0)
			{
				ISeasonSwitchJob result = this.SwitchQueue[0];
				this.SwitchQueue.RemoveAt(0);
				return result;
			}
			return null;
		}

		// Token: 0x06034C9C RID: 216220 RVA: 0x00D3EA90 File Offset: 0x00D3CC90
		public void ClearSwitchQueue()
		{
			this.FlushPendingCallbacks(false);
			this.SwitchQueue.Clear();
		}

		// Token: 0x06034C9D RID: 216221 RVA: 0x00D3EAA4 File Offset: 0x00D3CCA4
		public void ResetRuntime()
		{
			this.FlushPendingCallbacks(false);
			this.DriverPhase = ESeasonDriverPhase.Idle;
			this.LoopConfigInternal = null;
			this.LoopConfigByIndex = null;
			this.LoopState = null;
			this.SwitchQueue.Clear();
			this.RegisteredVolumesByAreaIdInternal.Clear();
			this.ActiveAreaIds.Clear();
			this.PlayerInsideAreaIdsInternal.Clear();
		}

		// Token: 0x06034C9E RID: 216222 RVA: 0x00D3EB00 File Offset: 0x00D3CD00
		private void FlushPendingCallbacks(bool success)
		{
			foreach (ISeasonSwitchJob seasonSwitchJob in this.SwitchQueue)
			{
				TSeasonSwitchCallback onComplete = seasonSwitchJob.OnComplete;
				if (onComplete != null)
				{
					seasonSwitchJob.OnComplete = null;
					try
					{
						onComplete(success);
					}
					catch (Exception ex)
					{
						global::Log instance = Singleton<global::Log>.Instance;
						ELogModule module = ELogModule.Season;
						ELogAuthor author = ELogAuthor.YSQ;
						string message = "切换回调抛异常";
						ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("error", ex.Message);
						instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
					}
				}
			}
		}

		// Token: 0x06034C9F RID: 216223 RVA: 0x00D3EBA8 File Offset: 0x00D3CDA8
		protected override bool OnInit()
		{
			Singleton<ResourceSystem>.Instance.LoadAsync<UMaterialParameterCollection>("/Game/Aki/Render/Shaders/Scene/Interaction/MPC_SceneInteraction.MPC_SceneInteraction", delegate([Nullable(2)] UMaterialParameterCollection result, string _)
			{
				if (result == null || !result.IsValid())
				{
					global::Log instance = Singleton<global::Log>.Instance;
					ELogModule module = ELogModule.Season;
					ELogAuthor author = ELogAuthor.YSQ;
					string message = "MPC加载失败";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Path", "/Game/Aki/Render/Shaders/Scene/Interaction/MPC_SceneInteraction.MPC_SceneInteraction");
					instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
					return;
				}
				this.MaterialAssetInternal = result;
				this.TimelineParamName = FNameUtil.GetDynamicFName("SeasonTransitionTimeLine");
				BP_MainGameInstance_C gameInstance = GlobalData.GameInstance;
				UWorld uworld = (gameInstance != null) ? gameInstance.GetWorld() : null;
				if (uworld == null)
				{
					return;
				}
				if (this.TimelineParamName != null)
				{
					this.CurrentValue = (double)UKismetMaterialLibrary.GetScalarParameterValue(uworld, this.MaterialAssetInternal, this.TimelineParamName.Value);
				}
				this.LastWrittenValue = new double?(this.CurrentValue);
			}, 100, "js_undefined");
			return true;
		}

		// Token: 0x06034CA0 RID: 216224 RVA: 0x00D3EBCE File Offset: 0x00D3CDCE
		protected override bool OnLeaveLevel()
		{
			this.ResetRuntime();
			return true;
		}

		// Token: 0x06034CA1 RID: 216225 RVA: 0x00D3EBD8 File Offset: 0x00D3CDD8
		protected override bool OnClear()
		{
			this.ResetRuntime();
			this.MaterialAssetInternal = null;
			this.TimelineParamName = null;
			return true;
		}

		// Token: 0x0401E679 RID: 124537
		private UMaterialParameterCollection MaterialAssetInternal;

		// Token: 0x0401E67A RID: 124538
		private ILoopSeasonChange LoopConfigInternal;

		// Token: 0x0401E67B RID: 124539
		[Nullable(1)]
		private readonly Dictionary<int, TsTriggerVolume> RegisteredVolumesByAreaIdInternal = new Dictionary<int, TsTriggerVolume>();

		// Token: 0x0401E67C RID: 124540
		[Nullable(1)]
		private readonly HashSet<int> PlayerInsideAreaIdsInternal = new HashSet<int>();
	}
}
