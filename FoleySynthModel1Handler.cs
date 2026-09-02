using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02002FFE RID: 12286
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class FoleySynthModel1Handler : FoleySynthHandlerBase<FoleySynthModel1Config>
{
	// Token: 0x06019095 RID: 102549 RVA: 0x0071B00C File Offset: 0x0071920C
	[NullableContext(2)]
	public FoleySynthModel1Handler(CharacterActorComponent actorComp, CharacterAkComponent akComp, int recordCount) : base(actorComp, akComp, recordCount)
	{
	}

	// Token: 0x06019096 RID: 102550 RVA: 0x0071B018 File Offset: 0x00719218
	protected override void OnInit(IReadOnlyList<FoleySynthModel1Config> configs)
	{
		foreach (FoleySynthModel1Config item in configs)
		{
			this.FoleySynthModelConfigs.Add(item);
		}
	}

	// Token: 0x06019097 RID: 102551 RVA: 0x0071B068 File Offset: 0x00719268
	protected unsafe override void OnParseBoneSpeedForAudio()
	{
		float num = 0f;
		float num2 = 0f;
		for (int i = 0; i < this.FoleySynthModelConfigs.Count; i++)
		{
			double speed = this.FoleySynthRecordsModel[this.RecordIndex][i].Speed;
			int state = this.FoleySynthModelDynamicConfigs[i].State;
			FoleySynthModel1Config foleySynthModel1Config = this.FoleySynthModelConfigs[i];
			switch (state)
			{
			case -1:
				if (speed > (double)foleySynthModel1Config.Ceil)
				{
					Singleton<AudioController>.Instance.PostEventByComponent(foleySynthModel1Config.CeilEvent, this.UeAkComp, null, null, null, null, true);
					this.FoleySynthModelDynamicConfigs[i].State = 1;
					num = (float)speed;
					num2 = foleySynthModel1Config.CeilInterpolation;
					if (this.IsDebug)
					{
						Log instance = Singleton<Log>.Instance;
						ELogModule module = ELogModule.Audio;
						ELogAuthor author = ELogAuthor.LJM;
						string message = "-------------Ak[FoleySynth][ParseBoneSpeedForAudio] Debug信息";
						<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Model", base.GetType().Name);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Actor", base.ActorComp.Actor.GetName());
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("Event", foleySynthModel1Config.CeilEvent);
						instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
					}
				}
				else if (speed < (double)foleySynthModel1Config.Floor)
				{
					Singleton<AudioController>.Instance.PostEventByComponent(foleySynthModel1Config.FloorEvent, this.UeAkComp, null, null, null, null, true);
					this.FoleySynthModelDynamicConfigs[i].State = 0;
					num = 0f;
					num2 = foleySynthModel1Config.FloorInterpolation;
					if (this.IsDebug)
					{
						Log instance2 = Singleton<Log>.Instance;
						ELogModule module2 = ELogModule.Audio;
						ELogAuthor author2 = ELogAuthor.LJM;
						string message2 = "-------------Ak[FoleySynth][ParseBoneSpeedForAudio] Debug信息";
						<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray3<ValueTuple<string, object>>);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("Model", base.GetType().Name);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("Actor", base.ActorComp.Actor.GetName());
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 2) = new ValueTuple<string, object>("Event", foleySynthModel1Config.FloorEvent);
						instance2.Info(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 3));
					}
				}
				this.UeAkComp.SetRTPCValue(foleySynthModel1Config.Rtpc, num, (int)num2, "");
				break;
			case 0:
				if (speed > (double)foleySynthModel1Config.Ceil)
				{
					Singleton<AudioController>.Instance.PostEventByComponent(foleySynthModel1Config.CeilEvent, this.UeAkComp, null, null, null, null, true);
					this.FoleySynthModelDynamicConfigs[i].State = 1;
					num = (float)speed;
					num2 = foleySynthModel1Config.CeilInterpolation;
					this.UeAkComp.SetRTPCValue(foleySynthModel1Config.Rtpc, num, (int)num2, "");
					if (this.IsDebug)
					{
						Log instance3 = Singleton<Log>.Instance;
						ELogModule module3 = ELogModule.Audio;
						ELogAuthor author3 = ELogAuthor.LJM;
						string message3 = "-------------Ak[FoleySynth][ParseBoneSpeedForAudio] Debug信息";
						<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray3 = default(<>y__InlineArray3<ValueTuple<string, object>>);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 0) = new ValueTuple<string, object>("Model", base.GetType().Name);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 1) = new ValueTuple<string, object>("Actor", base.ActorComp.Actor.GetName());
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 2) = new ValueTuple<string, object>("Event", foleySynthModel1Config.CeilEvent);
						instance3.Info(module3, author3, message3, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray3, 3));
					}
				}
				else
				{
					num = 0f;
					num2 = foleySynthModel1Config.FloorInterpolation;
				}
				break;
			case 1:
				if (speed < (double)foleySynthModel1Config.Floor)
				{
					Singleton<AudioController>.Instance.PostEventByComponent(foleySynthModel1Config.FloorEvent, this.UeAkComp, null, null, null, null, true);
					this.FoleySynthModelDynamicConfigs[i].State = 0;
					num = 0f;
					num2 = foleySynthModel1Config.FloorInterpolation;
					this.UeAkComp.SetRTPCValue(foleySynthModel1Config.Rtpc, num, (int)num2, "");
					if (this.IsDebug)
					{
						Log instance4 = Singleton<Log>.Instance;
						ELogModule module4 = ELogModule.Audio;
						ELogAuthor author4 = ELogAuthor.LJM;
						string message4 = "-------------Ak[FoleySynth][ParseBoneSpeedForAudio] Debug信息";
						<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray4 = default(<>y__InlineArray3<ValueTuple<string, object>>);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray4, 0) = new ValueTuple<string, object>("Model", base.GetType().Name);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray4, 1) = new ValueTuple<string, object>("Actor", base.ActorComp.Actor.GetName());
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray4, 2) = new ValueTuple<string, object>("Event", foleySynthModel1Config.FloorEvent);
						instance4.Info(module4, author4, message4, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray4, 3));
					}
				}
				else
				{
					num = (float)speed;
					num2 = foleySynthModel1Config.CeilInterpolation;
					this.UeAkComp.SetRTPCValue(foleySynthModel1Config.Rtpc, num, (int)num2, "");
				}
				break;
			}
		}
		if (this.IsDebug)
		{
			Log instance5 = Singleton<Log>.Instance;
			ELogModule module5 = ELogModule.Audio;
			ELogAuthor author5 = ELogAuthor.LJM;
			string message5 = "-------------Ak[FoleySynth][ParseBoneSpeedForAudio] Debug信息";
			<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray5 = default(<>y__InlineArray4<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray5, 0) = new ValueTuple<string, object>("Model", base.GetType().Name);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray5, 1) = new ValueTuple<string, object>("Actor", base.ActorComp.Actor.GetName());
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray5, 2) = new ValueTuple<string, object>("rtpcSpeed", num);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray5, 3) = new ValueTuple<string, object>("interpolation", num2);
			instance5.Info(module5, author5, message5, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray5, 4));
		}
	}
}
