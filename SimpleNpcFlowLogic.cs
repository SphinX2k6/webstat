using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.NPC.SimpleNpcFlow;
using CSharpScript.Game;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02003211 RID: 12817
[NullableContext(1)]
[Nullable(0)]
public class SimpleNpcFlowLogic : INpcIconFunction
{
	// Token: 0x0601AA04 RID: 109060 RVA: 0x007E6A33 File Offset: 0x007E4C33
	public SimpleNpcFlowLogic(TsSimpleNpc target)
	{
		this.Target = target;
		this.SelfLocation = new FVectorDouble?(target.D_K2_GetActorLocation());
	}

	// Token: 0x0601AA05 RID: 109061 RVA: 0x007E6A54 File Offset: 0x007E4C54
	public void StartFlowLogic()
	{
		this.FlowComponent = (this.Target.GetComponentByClass(SimpleNpcFlowComponent_C.StaticClass()) as SimpleNpcFlowComponent_C);
		if (this.FlowComponent == null)
		{
			return;
		}
		TArray<SimpleNpcFlowData> flowList = this.FlowComponent.FlowList;
		if (flowList != null && flowList.Num() > 0)
		{
			this.MultiplyLogic = new SimpleNpcMultiplyLogic(this.FlowComponent);
			this.InitTriggerRange();
			this.CheckFlowRangeLogic();
		}
	}

	// Token: 0x0601AA06 RID: 109062 RVA: 0x007E6AC4 File Offset: 0x007E4CC4
	private void InitTriggerRange()
	{
		FFloatRange checkRange = this.FlowComponent.CheckRange;
		this.MinCheckDistanceSquared = new float?(checkRange.LowerBound.Value * checkRange.LowerBound.Value);
		this.MaxCheckDistanceSquared = new float?(checkRange.UpperBound.Value * checkRange.UpperBound.Value);
	}

	// Token: 0x0601AA07 RID: 109063 RVA: 0x007E6B24 File Offset: 0x007E4D24
	public UniTask AddHeadView()
	{
		SimpleNpcFlowLogic.<AddHeadView>d__14 <AddHeadView>d__;
		<AddHeadView>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<AddHeadView>d__.<>4__this = this;
		<AddHeadView>d__.<>1__state = -1;
		<AddHeadView>d__.<>t__builder.Start<SimpleNpcFlowLogic.<AddHeadView>d__14>(ref <AddHeadView>d__);
		return <AddHeadView>d__.<>t__builder.Task;
	}

	// Token: 0x0601AA08 RID: 109064 RVA: 0x007E6B67 File Offset: 0x007E4D67
	public void ShowDialog(string text, float removeSeconds)
	{
		NpcIconComponent iconComponent = this.IconComponent;
		if (iconComponent == null)
		{
			return;
		}
		iconComponent.SetDialogueText(text, removeSeconds, false);
	}

	// Token: 0x0601AA09 RID: 109065 RVA: 0x007E6B7C File Offset: 0x007E4D7C
	public void HideDialog()
	{
		NpcIconComponent iconComponent = this.IconComponent;
		if (iconComponent == null)
		{
			return;
		}
		iconComponent.HideDialogueText();
	}

	// Token: 0x0601AA0A RID: 109066 RVA: 0x007E6B90 File Offset: 0x007E4D90
	public bool TryPlayMontage(string montagePath)
	{
		if (this.Target.Mesh == null)
		{
			return false;
		}
		if (this.Target.Mesh.AnimationMode == EAnimationMode.AnimationSingleNode)
		{
			return false;
		}
		UAnimInstance animInstance = this.Target.Mesh.AnimScriptInstance;
		if (animInstance == null)
		{
			return false;
		}
		string montageResPathByName = this.GetMontageResPathByName(montagePath);
		if (!string.IsNullOrEmpty(montageResPathByName))
		{
			Singleton<ResourceSystem>.Instance.LoadAsync<UAnimMontage>(montageResPathByName, delegate([Nullable(2)] UAnimMontage montageAsset, string _)
			{
				if (ObjectUtils.IsValid(montageAsset) && animInstance != null)
				{
					this.TempMontageRemoveTime = montageAsset.SequenceLength;
					animInstance.Montage_Play(montageAsset, 1f, EMontagePlayReturnType.MontageLength, 0f, true);
				}
			}, 100, "js_undefined");
		}
		return false;
	}

	// Token: 0x0601AA0B RID: 109067 RVA: 0x007E6C28 File Offset: 0x007E4E28
	private void InitMontageResPath()
	{
		if (!string.IsNullOrEmpty(this.MontageResPath))
		{
			return;
		}
		UAnimInstance animScriptInstance = this.Target.Mesh.AnimScriptInstance;
		if (animScriptInstance == null)
		{
			return;
		}
		string pathName = UKismetSystemLibrary.GetPathName(animScriptInstance);
		if (string.IsNullOrEmpty(pathName))
		{
			return;
		}
		string text = pathName.Substring(0, pathName.LastIndexOf("/"));
		text = text.Substring(0, text.LastIndexOf("/"));
		this.MontageResPath = string.Join("", new List<string>
		{
			text,
			"/Montage"
		});
	}

	// Token: 0x0601AA0C RID: 109068 RVA: 0x007E6CB8 File Offset: 0x007E4EB8
	[return: Nullable(2)]
	private string GetMontageResPathByName(string montageName)
	{
		if (string.IsNullOrEmpty(montageName) || montageName.Contains("/"))
		{
			return montageName;
		}
		this.InitMontageResPath();
		if (!string.IsNullOrEmpty(this.MontageResPath))
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(2, 3);
			defaultInterpolatedStringHandler.AppendFormatted(this.MontageResPath);
			defaultInterpolatedStringHandler.AppendLiteral("/");
			defaultInterpolatedStringHandler.AppendFormatted(montageName);
			defaultInterpolatedStringHandler.AppendLiteral(".");
			defaultInterpolatedStringHandler.AppendFormatted(montageName);
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}
		return null;
	}

	// Token: 0x0601AA0D RID: 109069 RVA: 0x007E6D38 File Offset: 0x007E4F38
	public void Tick(float deltaSeconds)
	{
		if (this.TempMontageRemoveTime > 0f)
		{
			this.TempMontageRemoveTime -= deltaSeconds;
			if (this.TempMontageRemoveTime < 0f)
			{
				this.StopMontage();
			}
		}
		if (this.MultiplyLogic != null)
		{
			this.CheckFlowRangeLogic();
			this.MultiplyLogic.Tick(deltaSeconds);
		}
	}

	// Token: 0x0601AA0E RID: 109070 RVA: 0x007E6D90 File Offset: 0x007E4F90
	public void StopMontage()
	{
		this.TempMontageRemoveTime = 0f;
		if (this.Target == null || this.Target.Mesh == null)
		{
			return;
		}
		if (this.Target.Mesh.AnimationMode == EAnimationMode.AnimationSingleNode)
		{
			return;
		}
		UAnimInstance animScriptInstance = this.Target.Mesh.AnimScriptInstance;
		if (animScriptInstance == null)
		{
			return;
		}
		if (animScriptInstance.IsAnyMontagePlaying())
		{
			animScriptInstance.Montage_Stop(0.3f, null);
		}
	}

	// Token: 0x0601AA0F RID: 109071 RVA: 0x007E6E08 File Offset: 0x007E5008
	private void CheckFlowRangeLogic()
	{
		TsBaseCharacter baseCharacter = Global.BaseCharacter;
		if (baseCharacter == null)
		{
			return;
		}
		FVectorDouble actorLocation = baseCharacter.CharacterActorComponent.ActorLocation;
		FVectorDouble value = this.SelfLocation.Value;
		double num = FVectorDouble.DistSquared2D(actorLocation, value);
		double num2 = num;
		float? num3 = this.MinCheckDistanceSquared;
		double? num4 = (num3 != null) ? new double?((double)num3.GetValueOrDefault()) : null;
		if (num2 < num4.GetValueOrDefault() & num4 != null)
		{
			if (!this.IsEnter)
			{
				if (!this.MultiplyLogic.IsPlaying && !this.Target.IsHiding)
				{
					this.MultiplyLogic.StartFlow();
				}
				else
				{
					this.MultiplyLogic.IsPause = false;
				}
			}
			this.IsEnter = true;
			return;
		}
		double num5 = num;
		num3 = this.MaxCheckDistanceSquared;
		num4 = ((num3 != null) ? new double?((double)num3.GetValueOrDefault()) : null);
		if (num5 < num4.GetValueOrDefault() & num4 != null)
		{
			this.IsEnter = false;
			this.MultiplyLogic.IsPause = true;
			return;
		}
		this.IsEnter = false;
		this.MultiplyLogic.IsPause = true;
		if (this.MultiplyLogic.IsPlaying)
		{
			this.MultiplyLogic.StopFlow();
		}
	}

	// Token: 0x0601AA10 RID: 109072 RVA: 0x007E6F43 File Offset: 0x007E5143
	public void FilterFlowWorldState()
	{
		SimpleNpcMultiplyLogic multiplyLogic = this.MultiplyLogic;
		if (multiplyLogic == null)
		{
			return;
		}
		multiplyLogic.FilterFlowWorldState();
	}

	// Token: 0x0601AA11 RID: 109073 RVA: 0x007E6F55 File Offset: 0x007E5155
	public void ForceStopFlow()
	{
		this.IsEnter = false;
		SimpleNpcMultiplyLogic multiplyLogic = this.MultiplyLogic;
		if (multiplyLogic != null && multiplyLogic.IsPlaying)
		{
			this.MultiplyLogic.StopFlow();
		}
	}

	// Token: 0x0601AA12 RID: 109074 RVA: 0x007E6F7D File Offset: 0x007E517D
	public void Dispose()
	{
		this.Target = null;
		this.FlowComponent = null;
		this.MultiplyLogic = null;
		NpcIconComponent iconComponent = this.IconComponent;
		if (iconComponent == null)
		{
			return;
		}
		iconComponent.Destroy();
	}

	// Token: 0x0601AA13 RID: 109075 RVA: 0x007E6FA4 File Offset: 0x007E51A4
	public Vector GetSelfLocation()
	{
		return this.Target.SelfLocationProxy;
	}

	// Token: 0x0601AA14 RID: 109076 RVA: 0x007E6FB1 File Offset: 0x007E51B1
	[NullableContext(2)]
	public UPrimitiveComponent GetAttachToMeshComponent()
	{
		return this.Target.Mesh;
	}

	// Token: 0x0601AA15 RID: 109077 RVA: 0x007E6FBE File Offset: 0x007E51BE
	public string GetAttachToSocketName()
	{
		return ConfigBase<NpcIconConfig>.Instance.GetNpcIconSocketName();
	}

	// Token: 0x0601AA16 RID: 109078 RVA: 0x007E6FCC File Offset: 0x007E51CC
	public void GetAttachToLocation(Vector outVec)
	{
		float capsuleHalfHeight = this.Target.CapsuleCollision.CapsuleHalfHeight;
		Vector selfLocationProxy = this.Target.SelfLocationProxy;
		outVec.Set(selfLocationProxy.X, selfLocationProxy.Y, selfLocationProxy.Z + (double)capsuleHalfHeight);
	}

	// Token: 0x0601AA17 RID: 109079 RVA: 0x007E7011 File Offset: 0x007E5211
	public double GetAddOffsetZ()
	{
		return 0.0;
	}

	// Token: 0x0601AA18 RID: 109080 RVA: 0x007E701C File Offset: 0x007E521C
	public bool IsShowNameInfo()
	{
		return false;
	}

	// Token: 0x0601AA19 RID: 109081 RVA: 0x007E701F File Offset: 0x007E521F
	public bool IsShowQuestInfo()
	{
		return false;
	}

	// Token: 0x0601AA1A RID: 109082 RVA: 0x007E7022 File Offset: 0x007E5222
	public bool IsShowPlayerInfo()
	{
		return false;
	}

	// Token: 0x0601AA1B RID: 109083 RVA: 0x007E7025 File Offset: 0x007E5225
	public bool CanTick(float deltaTime)
	{
		return true;
	}

	// Token: 0x0601AA1C RID: 109084 RVA: 0x007E7028 File Offset: 0x007E5228
	public bool IsInHeadItemShowRange(double disSquared, double maxShowRangeDisSquared, double minShowRangeDisSquared)
	{
		return disSquared < maxShowRangeDisSquared && disSquared > minShowRangeDisSquared;
	}

	// Token: 0x0601AA1D RID: 109085 RVA: 0x007E7034 File Offset: 0x007E5234
	public float GetDialogWorldScale3D()
	{
		return 0.5f;
	}

	// Token: 0x0400D791 RID: 55185
	private const float STOP_MONTAGE_BLEND_OUT_TIME = 0.3f;

	// Token: 0x0400D792 RID: 55186
	[Nullable(2)]
	private TsSimpleNpc Target;

	// Token: 0x0400D793 RID: 55187
	[Nullable(2)]
	private SimpleNpcFlowComponent_C FlowComponent;

	// Token: 0x0400D794 RID: 55188
	[Nullable(2)]
	private NpcIconComponent IconComponent;

	// Token: 0x0400D795 RID: 55189
	[Nullable(2)]
	private SimpleNpcMultiplyLogic MultiplyLogic;

	// Token: 0x0400D796 RID: 55190
	private float TempMontageRemoveTime;

	// Token: 0x0400D797 RID: 55191
	private bool IsEnter;

	// Token: 0x0400D798 RID: 55192
	[Nullable(2)]
	private string MontageResPath;

	// Token: 0x0400D799 RID: 55193
	private float? MinCheckDistanceSquared;

	// Token: 0x0400D79A RID: 55194
	private float? MaxCheckDistanceSquared;

	// Token: 0x0400D79B RID: 55195
	private readonly FVectorDouble? SelfLocation;
}
