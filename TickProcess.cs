using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02000BE5 RID: 3045
public class TickProcess : IStaticVariableResetter
{
	// Token: 0x06003227 RID: 12839 RVA: 0x0002169D File Offset: 0x0001F89D
	static TickProcess()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(TickProcess.CreateStaticDefaultValue), new Action(TickProcess.ResetStaticDefaultValue));
	}

	// Token: 0x06003228 RID: 12840 RVA: 0x000216BC File Offset: 0x0001F8BC
	public static void CreateStaticDefaultValue()
	{
	}

	// Token: 0x06003229 RID: 12841 RVA: 0x000216BE File Offset: 0x0001F8BE
	public static void ResetStaticDefaultValue()
	{
		TickProcess.Increment = 0;
	}

	// Token: 0x0600322A RID: 12842 RVA: 0x000216C6 File Offset: 0x0001F8C6
	public TickProcess()
	{
		this.Id = ++TickProcess.Increment;
	}

	// Token: 0x170000C5 RID: 197
	// (get) Token: 0x0600322B RID: 12843 RVA: 0x000216E8 File Offset: 0x0001F8E8
	public ETickingGroup Group
	{
		get
		{
			return this.GroupInternal;
		}
	}

	// Token: 0x0600322C RID: 12844 RVA: 0x000216F0 File Offset: 0x0001F8F0
	[NullableContext(1)]
	public void Init(Action<float> callback, ETickingGroup group, ETickProcessLifeType lifeType, float lifeTime = 0f, [Nullable(2)] string createReason = null)
	{
		this.TickCallback = callback;
		this.GroupInternal = group;
		this.LifeType = lifeType;
		this.LifeTime = lifeTime;
		this.PassTime = 0f;
		this.CreateReason = createReason;
	}

	// Token: 0x0600322D RID: 12845 RVA: 0x00021724 File Offset: 0x0001F924
	public bool Tick(float deltaTime)
	{
		if (this.TickCallback == null)
		{
			if (this.LifeType == ETickProcessLifeType.Forever)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Tick;
				ELogAuthor author = ELogAuthor.WLJ;
				string message = "[TickProcessSystem] Callback Invalid. 可能存在ForeverCallback未及时注销的情况";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("CreateReason", this.CreateReason);
				instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			return true;
		}
		this.TickCallback(deltaTime);
		if (this.LifeType == ETickProcessLifeType.Once)
		{
			return true;
		}
		if (this.LifeType == ETickProcessLifeType.Delay)
		{
			this.PassTime += deltaTime;
			if (this.PassTime >= this.LifeTime)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x0400050C RID: 1292
	public readonly int Id;

	// Token: 0x0400050D RID: 1293
	private static int Increment;

	// Token: 0x0400050E RID: 1294
	[Nullable(2)]
	private Action<float> TickCallback;

	// Token: 0x0400050F RID: 1295
	private ETickProcessLifeType LifeType;

	// Token: 0x04000510 RID: 1296
	private float LifeTime;

	// Token: 0x04000511 RID: 1297
	private float PassTime;

	// Token: 0x04000512 RID: 1298
	private ETickingGroup GroupInternal = ETickingGroup.TG_MAX;

	// Token: 0x04000513 RID: 1299
	[Nullable(2)]
	private string CreateReason;
}
