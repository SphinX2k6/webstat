using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Effect;
using CSharpScript.Game.NewWorld.Pawn.Component;
using UnrealEngine;

// Token: 0x02002C84 RID: 11396
[NullableContext(1)]
[Nullable(0)]
public class UiModelEffectComponent : UiModelComponentBase, IUiModelVisible, IUiModelSetDitherEffect
{
	// Token: 0x06016DBE RID: 93630 RVA: 0x006577E0 File Offset: 0x006559E0
	protected override void OnInit()
	{
		this.AnsControllerComponent = base.Owner.CheckGetComponent<UiModelAnsControllerComponent>();
		this.UiModelDataComponent = base.Owner.CheckGetComponent<UiModelDataComponent>();
		this.UiModelLoadComponent = base.Owner.GetComponentByCtor<UiModelLoadComponent>();
	}

	// Token: 0x06016DBF RID: 93631 RVA: 0x00657818 File Offset: 0x00655A18
	protected override void OnTick(float deltaTime)
	{
		if (!this.NeedSetUiScale || this.UiScaleEffectMap.Count == 0)
		{
			return;
		}
		List<int> list = new List<int>();
		foreach (KeyValuePair<int, USceneComponent> keyValuePair in this.UiScaleEffectMap)
		{
			int key = keyValuePair.Key;
			USceneComponent value = keyValuePair.Value;
			if (!Singleton<EffectSystem>.Instance.IsValid(key))
			{
				list.Add(key);
			}
			else
			{
				UNiagaraComponent sureNiagaraComponent = Singleton<EffectSystem>.Instance.GetSureNiagaraComponent(key);
				if (sureNiagaraComponent != null && value != null && value.IsValid())
				{
					float x = value.K2_GetComponentScale().X;
					sureNiagaraComponent.SetNiagaraVariableFloat("UiScale", x);
				}
			}
		}
		foreach (int key2 in list)
		{
			this.UiScaleEffectMap.Remove(key2);
		}
	}

	// Token: 0x06016DC0 RID: 93632 RVA: 0x00657928 File Offset: 0x00655B28
	protected override void OnStart()
	{
		UiModelAnsControllerComponent ansControllerComponent = this.AnsControllerComponent;
		if (ansControllerComponent != null)
		{
			ansControllerComponent.RegisterAnsTrigger("UiEffectAnsContext", new Action<UiAnsContextBase>(this.OnAnsBegin), new Action<UiAnsContextBase>(this.OnAnsEnd));
		}
		ControllerBase<UiModelEffectController>.Instance.SetEffectAdditionTimeScaleEnable(true, base.Owner.Id);
		this.NeedTick = true;
	}

	// Token: 0x06016DC1 RID: 93633 RVA: 0x00657980 File Offset: 0x00655B80
	protected override void OnEnd()
	{
		ControllerBase<UiModelEffectController>.Instance.SetEffectAdditionTimeScaleEnable(false, base.Owner.Id);
		this.DestroyAllEffect();
	}

	// Token: 0x06016DC2 RID: 93634 RVA: 0x006579A0 File Offset: 0x00655BA0
	public void OnModelVisibleChange(bool visible)
	{
		float ditherEffectValue = this.UiModelDataComponent.GetDitherEffectValue();
		if (visible && !this.EffectShowState && ditherEffectValue > this.ShowEffectDither)
		{
			this.EffectShowState = true;
			this.SetAllEffectShowState(this.EffectShowState);
		}
		if (!visible && this.EffectShowState)
		{
			this.EffectShowState = false;
			this.SetAllEffectShowState(this.EffectShowState);
		}
		if (visible)
		{
			this.ResumeAllEffectTime();
			return;
		}
		this.PauseAllEffectTime();
	}

	// Token: 0x06016DC3 RID: 93635 RVA: 0x00657A10 File Offset: 0x00655C10
	public void OnModelDitherEffectChange(float value)
	{
		bool visible = this.UiModelDataComponent.GetVisible();
		if (value > this.ShowEffectDither && !this.EffectShowState && visible)
		{
			this.EffectShowState = true;
			this.SetAllEffectShowState(this.EffectShowState);
		}
		if (value < this.HideEffectDither && this.EffectShowState)
		{
			this.EffectShowState = false;
			this.SetAllEffectShowState(this.EffectShowState);
		}
	}

	// Token: 0x06016DC4 RID: 93636 RVA: 0x00657A7C File Offset: 0x00655C7C
	public void PlayEffectOnRoot(string effectPath, USceneComponent sceneComponent, FName socketName, bool isForceShow)
	{
		this.PlayEffectByPath(effectPath, sceneComponent, socketName, true, false, Vector.ZeroVectorDouble, Rotator.ZeroRotator, Vector.OneVectorDouble, isForceShow, null, null);
	}

	// Token: 0x06016DC5 RID: 93637 RVA: 0x00657AA8 File Offset: 0x00655CA8
	public int PlayEffectByPath(string effectPath, USceneComponent sceneComponent, FName socket, bool attached, bool attachLocationOnly, FVectorDouble location, FRotator rotation, FVectorDouble scale, bool isForceShow, [Nullable(2)] EffectContext effectContext = null, [Nullable(2)] Action<ELoadEffectResult, int> callback = null)
	{
		EffectSystem instance = Singleton<EffectSystem>.Instance;
		UObject world = GlobalData.World;
		FTransformDouble? ftransformDouble = new FTransformDouble?(Singleton<MathUtils>.Instance.DefaultTransformDouble);
		int num = instance.SpawnEffect(world, ftransformDouble, effectPath, "[RoleAnimStateEffectManager.PlayEffect]", (effectContext != null) ? effectContext : new EffectContext(null, sceneComponent, false), EEffectType.UiScene3D, delegate(int handle)
		{
			OneOf<KuroEffectActorHandle, AActor> effectActor = Singleton<EffectSystem>.Instance.GetEffectActor(handle);
			if (!effectActor.IsValid())
			{
				return;
			}
			if (attached && !attachLocationOnly)
			{
				effectActor.K2_AttachToComponent(sceneComponent, new FName?(socket), EAttachmentRule.KeepRelative, EAttachmentRule.KeepRelative, EAttachmentRule.KeepRelative, false);
				FVector fvector = scale;
				FTransformDouble ftransformDouble2 = new FTransformDouble(ref rotation, ref location, ref fvector);
				FHitResult fhitResult = new FHitResult();
				effectActor.D_K2_SetActorRelativeTransform(ftransformDouble2, false, ref fhitResult, true);
			}
			else
			{
				Transform transform = Transform.Create(sceneComponent.D_GetSocketTransform(socket, ERelativeTransformSpace.RTS_World));
				Vector vector = Vector.Create();
				Rotator rotator = Rotator.Create();
				Rotator rotator2 = new Rotator();
				rotator2.DeepCopy(rotation);
				transform.TransformPosition(Vector.Create(location), vector);
				transform.TransformRotation(rotator2, rotator);
				FHitResult fhitResult2 = new FHitResult();
				OneOf<KuroEffectActorHandle, AActor> self = effectActor;
				FVectorDouble fvectorDouble = vector.ToUeVector(false);
				FRotator frotator = rotator.ToUeRotator();
				self.D_K2_SetActorLocationAndRotation(fvectorDouble, frotator, false, ref fhitResult2, true);
				effectActor.D_SetActorScale3D(scale);
			}
			effectActor.SetActorHiddenInGame(!this.EffectShowState && !isForceShow);
			if (this.NeedSetUiScale)
			{
				this.UiScaleEffectMap[handle] = sceneComponent;
			}
		}, callback, null, false, false);
		if (Singleton<EffectSystem>.Instance.IsValid(num))
		{
			this.EffectHandleSet.Add(num);
		}
		return num;
	}

	// Token: 0x06016DC6 RID: 93638 RVA: 0x00657B74 File Offset: 0x00655D74
	public int PlayEffectByContext(UiModelEffectPlayContext context)
	{
		EffectSystem instance = Singleton<EffectSystem>.Instance;
		UObject world = GlobalData.World;
		FTransformDouble? ftransformDouble = new FTransformDouble?(context.Transform);
		int num = instance.SpawnEffect(world, ftransformDouble, context.EffectPath, "[RoleAnimStateEffectManager.PlayEffect]", new EffectContext(null, context.AttachTargetComponent, false), context.EffectType, delegate(int handle)
		{
			OneOf<KuroEffectActorHandle, AActor> effectActor = Singleton<EffectSystem>.Instance.GetEffectActor(handle);
			if (!effectActor.IsValid())
			{
				return;
			}
			if (context.Attached && !context.AttachLocationOnly)
			{
				effectActor.K2_AttachToComponent(context.AttachTargetComponent, new FName?(context.SocketName), context.LocationRule, context.RotationRule, context.ScaleRule, false);
				UiModelEffectPlayContext context2 = context;
				UiModelEffectPlayContext context3 = context;
				FVector fvector = context.Scale;
				FTransformDouble ftransformDouble2 = new FTransformDouble(ref context2.Rotator, ref context3.Location, ref fvector);
				FHitResult fhitResult = new FHitResult();
				effectActor.D_K2_SetActorRelativeTransform(ftransformDouble2, false, ref fhitResult, true);
			}
			else
			{
				Transform transform = Transform.Create(context.AttachTargetComponent.D_GetSocketTransform(context.SocketName, ERelativeTransformSpace.RTS_World));
				Vector vector = Vector.Create();
				Rotator rotator = Rotator.Create();
				Rotator rotator2 = new Rotator();
				rotator2.DeepCopy(context.Rotator);
				transform.TransformPosition(Vector.Create(context.Location), vector);
				transform.TransformRotation(rotator2, rotator);
				FHitResult fhitResult2 = new FHitResult();
				OneOf<KuroEffectActorHandle, AActor> self = effectActor;
				FVectorDouble fvectorDouble = vector.ToUeVector(false);
				FRotator frotator = rotator.ToUeRotator();
				self.D_K2_SetActorLocationAndRotation(fvectorDouble, frotator, false, ref fhitResult2, true);
				effectActor.D_SetActorScale3D(context.Scale);
			}
			effectActor.SetActorHiddenInGame(!this.EffectShowState && !context.IsForceShow);
			if (this.NeedSetUiScale && context.AttachTargetComponent != null)
			{
				this.UiScaleEffectMap[handle] = context.AttachTargetComponent;
			}
		}, context.Callback, null, false, false);
		if (Singleton<EffectSystem>.Instance.IsValid(num))
		{
			this.EffectHandleSet.Add(num);
		}
		return num;
	}

	// Token: 0x06016DC7 RID: 93639 RVA: 0x00657C24 File Offset: 0x00655E24
	public void PlayEffectByAnsContext(UiEffectAnsContext context)
	{
		if (this.AnsEffectMap.ContainsKey(context))
		{
			return;
		}
		if (context.PlayOnEnd)
		{
			return;
		}
		UiModelLoadComponent uiModelLoadComponent = this.UiModelLoadComponent;
		Dictionary<string, string> dictionary = (uiModelLoadComponent != null) ? uiModelLoadComponent.GetReplaceEffectMap() : null;
		string text2;
		string text = (dictionary != null && dictionary.TryGetValue(context.EffectPath, out text2)) ? text2 : context.EffectPath;
		text != context.EffectPath;
		int num = this.PlayEffectByPath(text, context.MeshComponent, context.Socket, context.Attached, context.AttachLocationOnly, context.Location, context.Rotation, context.Scale, false, context.EffectContext, null);
		if (context.OnEffectSpawn != null)
		{
			context.OnEffectSpawn(context.MeshComponent, num);
		}
		this.AnsEffectMap[context] = num;
		context.Handle = new int?(num);
	}

	// Token: 0x06016DC8 RID: 93640 RVA: 0x00657CF4 File Offset: 0x00655EF4
	public void StopEffectByAnsContext(UiEffectAnsContext context)
	{
		if (context.PlayOnEnd)
		{
			UiModelLoadComponent uiModelLoadComponent = this.UiModelLoadComponent;
			Dictionary<string, string> dictionary = (uiModelLoadComponent != null) ? uiModelLoadComponent.GetReplaceEffectMap() : null;
			string text2;
			string text = (dictionary != null && dictionary.TryGetValue(context.EffectPath, out text2)) ? text2 : context.EffectPath;
			text != context.EffectPath;
			this.PlayEffectByPath(text, context.MeshComponent, context.Socket, context.Attached, context.AttachLocationOnly, context.Location, context.Rotation, context.Scale, false, context.EffectContext, null);
			return;
		}
		int effectHandle;
		if (this.AnsEffectMap.TryGetValue(context, out effectHandle))
		{
			this.StopEffect(effectHandle, context.FasterStop);
			this.AnsEffectMap.Remove(context);
		}
	}

	// Token: 0x06016DC9 RID: 93641 RVA: 0x00657DAC File Offset: 0x00655FAC
	public void HideEffectByAnsContext(UiEffectAnsContext context)
	{
		int handle;
		if (this.AnsEffectMap.TryGetValue(context, out handle))
		{
			Singleton<EffectSystem>.Instance.SetEffectHidden(handle, true, null, false);
		}
	}

	// Token: 0x06016DCA RID: 93642 RVA: 0x00657DD8 File Offset: 0x00655FD8
	public void DestroyAllEffect()
	{
		if (this.EffectHandleSet == null || this.EffectHandleSet.Count == 0)
		{
			return;
		}
		foreach (int num in this.EffectHandleSet)
		{
			if (Singleton<EffectSystem>.Instance.IsValid(num))
			{
				Singleton<EffectSystem>.Instance.SetEffectHidden(num, true, null, false);
				Singleton<EffectSystem>.Instance.StopEffectById(num, "[RoleAnimStateEffectManager.RecycleEffect]", true, null);
			}
		}
		this.EffectHandleSet.Clear();
		this.AnsEffectMap.Clear();
		this.UiScaleEffectMap.Clear();
	}

	// Token: 0x06016DCB RID: 93643 RVA: 0x00657E94 File Offset: 0x00656094
	public void SetAllEffectShowState(bool state)
	{
		foreach (int handle in this.EffectHandleSet)
		{
			Singleton<EffectSystem>.Instance.SetEffectHidden(handle, !state, null, false);
		}
	}

	// Token: 0x06016DCC RID: 93644 RVA: 0x00657EF4 File Offset: 0x006560F4
	private void ResumeAllEffectTime()
	{
		foreach (int id in this.EffectHandleSet)
		{
			Singleton<EffectSystem>.Instance.SetAdditionTimeScale(ETimeScaleSourceType.UiModel, id, 1f);
		}
	}

	// Token: 0x06016DCD RID: 93645 RVA: 0x00657F54 File Offset: 0x00656154
	private void PauseAllEffectTime()
	{
		foreach (int id in this.EffectHandleSet)
		{
			Singleton<EffectSystem>.Instance.SetAdditionTimeScale(ETimeScaleSourceType.UiModel, id, 0f);
		}
	}

	// Token: 0x06016DCE RID: 93646 RVA: 0x00657FB4 File Offset: 0x006561B4
	public void StopEffect(int effectHandle, bool bFastStop = true)
	{
		if (Singleton<EffectSystem>.Instance.IsValid(effectHandle))
		{
			Singleton<EffectSystem>.Instance.StopEffectById(effectHandle, "[RoleAnimStateEffectManager.StopEffect]", bFastStop, null);
			if (bFastStop)
			{
				this.EffectHandleSet.Remove(effectHandle);
			}
		}
		else
		{
			this.EffectHandleSet.Remove(effectHandle);
		}
		this.UiScaleEffectMap.Remove(effectHandle);
	}

	// Token: 0x06016DCF RID: 93647 RVA: 0x00658015 File Offset: 0x00656215
	public void OnAnsBegin(UiAnsContextBase ansContext)
	{
		this.PlayEffectByAnsContext(ansContext as UiEffectAnsContext);
	}

	// Token: 0x06016DD0 RID: 93648 RVA: 0x00658024 File Offset: 0x00656224
	public void OnAnsEnd(UiAnsContextBase ansContext)
	{
		UiEffectAnsContext uiEffectAnsContext = ansContext as UiEffectAnsContext;
		FName? ansSlotName = uiEffectAnsContext.EffectContext.AnsSlotName;
		if (ansSlotName != null && !ansSlotName.Value.Equals(FNameUtil.NONE) && !this.CheckHasOtherSameSlotAns(uiEffectAnsContext))
		{
			this.HideEffectByAnsContext(uiEffectAnsContext);
		}
		this.StopEffectByAnsContext(uiEffectAnsContext);
	}

	// Token: 0x06016DD1 RID: 93649 RVA: 0x0065807C File Offset: 0x0065627C
	private bool CheckHasOtherSameSlotAns(UiEffectAnsContext inEffectAnsContext)
	{
		FName? ansSlotName = inEffectAnsContext.EffectContext.AnsSlotName;
		if (ansSlotName == null || ansSlotName.Value.Equals(FNameUtil.NONE))
		{
			return false;
		}
		foreach (UiAnsContextBase uiAnsContextBase in this.AnsControllerComponent.GetAnsContextSet("UiEffectAnsContext").ContextSet)
		{
			if (uiAnsContextBase != inEffectAnsContext)
			{
				UiEffectAnsContext uiEffectAnsContext = uiAnsContextBase as UiEffectAnsContext;
				if (uiEffectAnsContext.ExistCount > 0 && uiEffectAnsContext.EffectContext.AnsSlotName != null && uiEffectAnsContext.EffectContext.AnsSlotName.Value.Equals(ansSlotName))
				{
					return true;
				}
			}
		}
		return false;
	}

	// Token: 0x0400B05D RID: 45149
	public bool NeedSetUiScale;

	// Token: 0x0400B05E RID: 45150
	private readonly HashSet<int> EffectHandleSet = new HashSet<int>();

	// Token: 0x0400B05F RID: 45151
	private readonly Dictionary<UiEffectAnsContext, int> AnsEffectMap = new Dictionary<UiEffectAnsContext, int>();

	// Token: 0x0400B060 RID: 45152
	[Nullable(2)]
	private UiModelAnsControllerComponent AnsControllerComponent;

	// Token: 0x0400B061 RID: 45153
	[Nullable(2)]
	private UiModelDataComponent UiModelDataComponent;

	// Token: 0x0400B062 RID: 45154
	[Nullable(2)]
	private UiModelLoadComponent UiModelLoadComponent;

	// Token: 0x0400B063 RID: 45155
	private readonly Dictionary<int, USceneComponent> UiScaleEffectMap = new Dictionary<int, USceneComponent>();

	// Token: 0x0400B064 RID: 45156
	private bool EffectShowState = true;

	// Token: 0x0400B065 RID: 45157
	private readonly float ShowEffectDither = 0.5f;

	// Token: 0x0400B066 RID: 45158
	private readonly float HideEffectDither = 0.5f;
}
