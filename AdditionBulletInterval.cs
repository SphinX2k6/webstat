using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02002F40 RID: 12096
[NullableContext(1)]
[Nullable(0)]
public class AdditionBulletInterval : BuffEffect
{
	// Token: 0x06018C13 RID: 101395 RVA: 0x006FF278 File Offset: 0x006FD478
	public AdditionBulletInterval(int activeHandleId, int index, RequireAndLimits requireAndLimits, BaseBuffComponent ownerBuffComponent, [Nullable(2)] CharacterBuffComponent instigatorBuffComponent) : base(activeHandleId, index, requireAndLimits, ownerBuffComponent, instigatorBuffComponent)
	{
	}

	// Token: 0x06018C14 RID: 101396 RVA: 0x006FF292 File Offset: 0x006FD492
	[return: Nullable(2)]
	public override object OnExecute(params object[] parameters)
	{
		return null;
	}

	// Token: 0x06018C15 RID: 101397 RVA: 0x006FF298 File Offset: 0x006FD498
	protected unsafe override void InitParameters(ExtraEffectParameters parameters)
	{
		string[] extraEffectParameters_ = parameters.ExtraEffectParameters_;
		int num = (extraEffectParameters_ != null) ? extraEffectParameters_.Length : 0;
		for (int i = 0; i < num; i++)
		{
			string text = extraEffectParameters_[i];
			string[] array = text.Split('#', StringSplitOptions.None);
			if (array.Length < 2)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.BuffItem;
				ELogAuthor author = ELogAuthor.HCW;
				string message = "参数数量不足, 需要2个";
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
				float value = float.Parse(array[1]);
				this.BulletIntervalMap[key] = value;
			}
		}
	}

	// Token: 0x06018C16 RID: 101398 RVA: 0x006FF3A0 File Offset: 0x006FD5A0
	public float GetBulletInterval(string bulletRowName)
	{
		float valueOrDefault = this.BulletIntervalMap.GetValueOrDefault(bulletRowName, 0f);
		int stackCount = base.Buff.StackCount;
		return valueOrDefault * (float)stackCount;
	}

	// Token: 0x0400C0CE RID: 49358
	private const int INTERVAL_SCALE_PARAMS_LEN = 2;

	// Token: 0x0400C0CF RID: 49359
	private const int INTERVAL_SCALE_INDEX_BULLETROWNAME = 0;

	// Token: 0x0400C0D0 RID: 49360
	private const int INTERVAL_SCALE_INDEX_INTERVAL = 1;

	// Token: 0x0400C0D1 RID: 49361
	private readonly Dictionary<string, float> BulletIntervalMap = new Dictionary<string, float>();
}
