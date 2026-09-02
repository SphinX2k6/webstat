using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02003003 RID: 12291
[NullableContext(1)]
[Nullable(0)]
public class FoleySynthHandlerBase<[Nullable(0)] T> : FoleySynthHandlerBase where T : FoleySynthModelConfig
{
	// Token: 0x060190B2 RID: 102578 RVA: 0x0071BE03 File Offset: 0x0071A003
	[NullableContext(2)]
	public FoleySynthHandlerBase(CharacterActorComponent actorComp, CharacterAkComponent akComp, int recordCount) : base(actorComp, akComp, recordCount)
	{
	}

	// Token: 0x060190B3 RID: 102579 RVA: 0x0071BE1C File Offset: 0x0071A01C
	public virtual void Init(IReadOnlyList<T> configs)
	{
		this.OnInit(configs);
		this.RecordIndex = 0;
		this.RecordErrorFlag = 0;
		this.RecordTickCount = 0;
		CharacterAkComponent akComp = base.AkComp;
		this.UeAkComp = ((akComp != null) ? akComp.GetAkComponentBySocketName(Singleton<CharacterNameDefines>.Instance.HIT_CASE_NAME) : null);
		this.IsActive = true;
		for (int i = 0; i < base.RecordCount; i++)
		{
			List<FoleySynthRecord> list = new List<FoleySynthRecord>();
			for (int j = 0; j < this.FoleySynthModelConfigs.Count; j++)
			{
				list.Add(new FoleySynthRecord());
			}
			this.FoleySynthRecordsModel.Add(list);
		}
		for (int k = 0; k < this.FoleySynthModelConfigs.Count; k++)
		{
			this.PreModelBoneComponentLocations.Add(Vector.Create());
			this.FoleySynthModelDynamicConfigs.Add(new FoleySynthDynamicConfig());
		}
	}

	// Token: 0x060190B4 RID: 102580 RVA: 0x0071BEE8 File Offset: 0x0071A0E8
	protected virtual void OnInit(IReadOnlyList<T> config)
	{
	}

	// Token: 0x060190B5 RID: 102581 RVA: 0x0071BEEC File Offset: 0x0071A0EC
	protected override void PreCacheBoneLocation()
	{
		for (int i = 0; i < this.FoleySynthModelConfigs.Count; i++)
		{
			T t = this.FoleySynthModelConfigs[i];
			FTransformDouble ftransformDouble = base.ActorComp.Actor.Mesh.D_GetSocketTransform(t.BoneName.Value, ERelativeTransformSpace.RTS_Component);
			Vector vector = this.PreModelBoneComponentLocations[i];
			FVectorDouble translation = ftransformDouble.GetTranslation();
			vector.DeepCopy(translation);
		}
	}

	// Token: 0x060190B6 RID: 102582 RVA: 0x0071BF60 File Offset: 0x0071A160
	protected override void CalBoneRecord(float deltaTime)
	{
		this.RecordIndex = (this.RecordIndex + 1) % base.RecordCount;
		int preRecordIndex = base.GetPreRecordIndex(1);
		for (int i = 0; i < this.FoleySynthModelConfigs.Count; i++)
		{
			T t = this.FoleySynthModelConfigs[i];
			FVectorDouble fvectorDouble = base.ActorComp.Actor.Mesh.D_GetSocketLocation(t.BoneName.Value);
			this.TempBoneLocation.DeepCopy(fvectorDouble);
			this.TempBoneLocation.SubtractionEqual(base.ActorComp.ActorLocationProxy);
			ValueTuple<double, double> valueTuple = base.CalBoneSpeed(this.TempBoneLocation, this.PreModelBoneComponentLocations[i], deltaTime);
			double item = valueTuple.Item1;
			double item2 = valueTuple.Item2;
			this.FoleySynthRecordsModel[this.RecordIndex][i].Speed = item;
			this.FoleySynthRecordsModel[this.RecordIndex][i].BoneSpeed = item2;
			double speed = this.FoleySynthRecordsModel[preRecordIndex][i].Speed;
			double acceleration = (item - speed) / (double)deltaTime;
			this.FoleySynthRecordsModel[this.RecordIndex][i].Acceleration = acceleration;
			this.PreModelBoneComponentLocations[i].DeepCopy(this.TempBoneLocation);
			if (this.IsDebug)
			{
				base.SaveDebugInfo(t.BoneName, item, acceleration, item2);
			}
		}
	}

	// Token: 0x0400C40B RID: 50187
	protected readonly List<T> FoleySynthModelConfigs = new List<T>();
}
