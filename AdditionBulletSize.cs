using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02002F3E RID: 12094
[NullableContext(1)]
[Nullable(0)]
public class AdditionBulletSize : BuffEffect
{
	// Token: 0x06018C0A RID: 101386 RVA: 0x006FED7C File Offset: 0x006FCF7C
	public AdditionBulletSize(int activeHandleId, int index, RequireAndLimits requireAndLimits, BaseBuffComponent ownerBuffComponent, [Nullable(2)] CharacterBuffComponent instigatorBuffComponent) : base(activeHandleId, index, requireAndLimits, ownerBuffComponent, instigatorBuffComponent)
	{
	}

	// Token: 0x06018C0B RID: 101387 RVA: 0x006FEDA1 File Offset: 0x006FCFA1
	[return: Nullable(2)]
	public override object OnExecute(params object[] parameters)
	{
		return null;
	}

	// Token: 0x06018C0C RID: 101388 RVA: 0x006FEDA4 File Offset: 0x006FCFA4
	protected unsafe override void InitParameters(ExtraEffectParameters parameters)
	{
		string[] extraEffectParameters_ = parameters.ExtraEffectParameters_;
		int num = (extraEffectParameters_ != null) ? extraEffectParameters_.Length : 0;
		for (int i = 0; i < num; i++)
		{
			string text = extraEffectParameters_[i];
			string[] array = text.Split('#', StringSplitOptions.None);
			if (array.Length < 4)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.BuffItem;
				ELogAuthor author = ELogAuthor.HCW;
				string message = "参数数量不足, 需要4个";
				<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray4<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Buff", this.BuffId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("参数", text);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("参数索引", i);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("参数数量", num);
				instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 4));
			}
			else
			{
				string key = array[0];
				float item = float.Parse(array[1]);
				float item2 = float.Parse(array[2]);
				float item3 = float.Parse(array[3]);
				this.BulletScaleMap[key] = i * 3;
				this.ScaleArray.Add(item);
				this.ScaleArray.Add(item2);
				this.ScaleArray.Add(item3);
			}
		}
	}

	// Token: 0x06018C0D RID: 101389 RVA: 0x006FEEE8 File Offset: 0x006FD0E8
	[NullableContext(0)]
	public unsafe ValueTuple<float, float, float>? GetBulletSizeScale([Nullable(1)] string bulletRowName)
	{
		int num;
		if (!this.BulletScaleMap.TryGetValue(bulletRowName, out num) || num < 0)
		{
			return null;
		}
		if (num >= this.ScaleArray.Count)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.BuffItem;
			ELogAuthor author = ELogAuthor.HCW;
			string message = "获取到的索引超过了参数数量";
			<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray4<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Buff", this.BuffId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("参数索引", num);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("参数数量", this.ScaleArray.Count);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("子弹ID", bulletRowName);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 4));
			return null;
		}
		int stackCount = base.Buff.StackCount;
		return new ValueTuple<float, float, float>?(new ValueTuple<float, float, float>(this.ScaleArray[num] * (float)stackCount, this.ScaleArray[num + 1] * (float)stackCount, this.ScaleArray[num + 2] * (float)stackCount));
	}

	// Token: 0x0400C0C3 RID: 49347
	private const int SIZE_SCALE_PARAMS_LEN = 4;

	// Token: 0x0400C0C4 RID: 49348
	private const int SIZE_SCALE_INDEX_BULLETROWNAME = 0;

	// Token: 0x0400C0C5 RID: 49349
	private const int SIZE_SCALE_INDEX_X = 1;

	// Token: 0x0400C0C6 RID: 49350
	private const int SIZE_SCALE_INDEX_Y = 2;

	// Token: 0x0400C0C7 RID: 49351
	private const int SIZE_SCALE_INDEX_Z = 3;

	// Token: 0x0400C0C8 RID: 49352
	private readonly Dictionary<string, int> BulletScaleMap = new Dictionary<string, int>();

	// Token: 0x0400C0C9 RID: 49353
	private readonly List<float> ScaleArray = new List<float>();
}
