using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02002FFF RID: 12287
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class FoleySynthModel2Handler : FoleySynthHandlerBase<FoleySynthModel2Config>
{
	// Token: 0x06019098 RID: 102552 RVA: 0x0071B5EA File Offset: 0x007197EA
	[NullableContext(2)]
	public FoleySynthModel2Handler(CharacterActorComponent actorComp, CharacterAkComponent akComp, int recordCount) : base(actorComp, akComp, recordCount)
	{
	}

	// Token: 0x170021B8 RID: 8632
	// (get) Token: 0x06019099 RID: 102553 RVA: 0x0071B600 File Offset: 0x00719800
	// (set) Token: 0x0601909A RID: 102554 RVA: 0x0071B608 File Offset: 0x00719808
	public int VelocityMaxCount { get; set; }

	// Token: 0x0601909B RID: 102555 RVA: 0x0071B614 File Offset: 0x00719814
	protected override void OnInit(IReadOnlyList<FoleySynthModel2Config> configs)
	{
		foreach (FoleySynthModel2Config item in configs)
		{
			this.FoleySynthModelConfigs.Add(item);
			this.CacheSpeed.Add(-1f);
		}
	}

	// Token: 0x0601909C RID: 102556 RVA: 0x0071B674 File Offset: 0x00719874
	protected unsafe override void OnParseBoneSpeedForAudio()
	{
		List<float> list = new List<float>();
		List<float> list2 = new List<float>();
		for (int i = 0; i < this.FoleySynthModelConfigs.Count; i++)
		{
			list.Add(0f);
			list2.Add(0f);
		}
		for (int j = 0; j < this.FoleySynthModelConfigs.Count; j++)
		{
			if (this.CacheSpeed[j] == -1f)
			{
				FoleySynthModel2Config foleySynthModel2Config = this.FoleySynthModelConfigs[j];
				if (base.GetCurrentRecord(j).Speed > (double)foleySynthModel2Config.Ceil)
				{
					Singleton<AudioController>.Instance.PostEventByComponent(foleySynthModel2Config.CeilEvent, this.UeAkComp, null, null, null, null, true);
					if (this.IsDebug)
					{
						Log instance = Singleton<Log>.Instance;
						ELogModule module = ELogModule.Audio;
						ELogAuthor author = ELogAuthor.LJM;
						string message = "-------------Ak[FoleySynth][ParseBoneSpeedForAudio] Debug信息";
						<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Model", base.GetType().Name);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Actor", base.ActorComp.Actor.GetName());
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("Event", foleySynthModel2Config.CeilEvent);
						instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
					}
					for (int k = 0; k < base.RecordCount; k++)
					{
						double acceleration = this.FoleySynthRecordsModel[k][j].Acceleration;
						if (acceleration > (double)list2[j])
						{
							list2[j] = (float)acceleration;
						}
					}
					for (int l = 0; l < this.VelocityMaxCount; l++)
					{
						int preRecordIndex = base.GetPreRecordIndex(l);
						double speed = this.FoleySynthRecordsModel[preRecordIndex][j].Speed;
						if (speed > (double)list[j])
						{
							list[j] = (float)speed;
						}
					}
					this.UeAkComp.SetRTPCValue(foleySynthModel2Config.RtpcVelMax, list[j], 0, "");
					this.UeAkComp.SetRTPCValue(foleySynthModel2Config.RtpcAccMax, list2[j], 0, "");
					this.CacheSpeed[j] = list[j];
				}
			}
			else
			{
				FoleySynthModel2Config foleySynthModel2Config2 = this.FoleySynthModelConfigs[j];
				double speed2 = base.GetCurrentRecord(j).Speed;
				if (speed2 < (double)foleySynthModel2Config2.Floor || speed2 < (double)(this.CacheSpeed[j] * foleySynthModel2Config2.FloorPrecent))
				{
					Singleton<AudioController>.Instance.PostEventByComponent(foleySynthModel2Config2.FloorEvent, this.UeAkComp, null, null, null, null, true);
					if (this.IsDebug)
					{
						Log instance2 = Singleton<Log>.Instance;
						ELogModule module2 = ELogModule.Audio;
						ELogAuthor author2 = ELogAuthor.LJM;
						string message2 = "-------------Ak[FoleySynth][ParseBoneSpeedForAudio] Debug信息";
						<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray3<ValueTuple<string, object>>);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("Model", base.GetType().Name);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("Actor", base.ActorComp.Actor.GetName());
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 2) = new ValueTuple<string, object>("Event", foleySynthModel2Config2.FloorEvent);
						instance2.Info(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 3));
					}
					this.UeAkComp.SetRTPCValue(foleySynthModel2Config2.RtpcVelDur, (float)speed2, (int)foleySynthModel2Config2.FloorInterpolation, "");
					this.CacheSpeed[j] = -1f;
				}
				else
				{
					this.UeAkComp.SetRTPCValue(foleySynthModel2Config2.RtpcVelDur, (float)speed2, (int)foleySynthModel2Config2.CeilInterpolation, "");
				}
			}
		}
	}

	// Token: 0x0400C3F5 RID: 50165
	private readonly List<float> CacheSpeed = new List<float>();
}
