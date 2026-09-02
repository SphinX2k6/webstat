using System;
using System.Runtime.CompilerServices;

// Token: 0x02002E0C RID: 11788
[NullableContext(1)]
[Nullable(0)]
public class BulletPool : IStaticVariableResetter
{
	// Token: 0x06017D2C RID: 97580 RVA: 0x006A50BD File Offset: 0x006A32BD
	static BulletPool()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(BulletPool.CreateStaticDefaultValue), new Action(BulletPool.ResetStaticDefaultValue));
	}

	// Token: 0x06017D2D RID: 97581 RVA: 0x006A50DC File Offset: 0x006A32DC
	public static void Init()
	{
		for (int i = 0; i < 10; i++)
		{
			BulletEntity bulletEntity = BulletPool.BulletEntityPool.Create("bulletEntity");
			Singleton<EntitySystem>.Instance.Init(bulletEntity);
			Singleton<EntitySystem>.Instance.DeSpawn<BulletEntity>(bulletEntity);
			BulletPool.BulletEntityPool.Put(bulletEntity);
		}
		for (int j = 0; j < 10; j++)
		{
			BulletHitActorData value = BulletPool.BulletHitActorDataPool.Create();
			BulletPool.BulletHitActorDataPool.Put(value);
		}
		for (int k = 0; k < 10; k++)
		{
			BulletConditionResult value2 = BulletPool.BulletConditionResultPool.Create();
			BulletPool.BulletConditionResultPool.Put(value2);
		}
		for (int l = 0; l < 10; l++)
		{
			BulletPool.VectorPool.PreloadAdd(Vector.Create());
		}
		for (int m = 0; m < 10; m++)
		{
			BulletPool.RotatorPool.PreloadAdd(Rotator.Create());
		}
		for (int n = 0; n < 10; n++)
		{
			BulletPool.BulletHitTempResultPool.PreloadAdd(new BulletHitTempResult());
		}
	}

	// Token: 0x06017D2E RID: 97582 RVA: 0x006A51D8 File Offset: 0x006A33D8
	public static void Clear()
	{
		BulletPool.BulletEntityPool.Clear();
		BulletPool.BulletHitActorDataPool.Clear();
		BulletPool.BulletConditionResultPool.Clear();
		BulletPool.VectorPool.Clear();
		BulletPool.RotatorPool.Clear();
	}

	// Token: 0x17002051 RID: 8273
	// (get) Token: 0x06017D2F RID: 97583 RVA: 0x006A520C File Offset: 0x006A340C
	public static Lru<string, BulletEntity> BulletEntityPool
	{
		get
		{
			return BulletPool._bulletEntityPool;
		}
	}

	// Token: 0x06017D30 RID: 97584 RVA: 0x006A5214 File Offset: 0x006A3414
	public static BulletEntity CreateBulletEntity()
	{
		BulletEntity bulletEntity = BulletPool.BulletEntityPool.Get("bulletEntity");
		if (bulletEntity != null)
		{
			Singleton<EntitySystem>.Instance.Respawn<BulletEntity>(bulletEntity, false, 0, null);
		}
		else
		{
			bulletEntity = BulletPool.BulletEntityPool.Create("bulletEntity");
			Singleton<EntitySystem>.Instance.Init(bulletEntity);
		}
		return bulletEntity;
	}

	// Token: 0x06017D31 RID: 97585 RVA: 0x006A5262 File Offset: 0x006A3462
	public static void RecycleBulletEntity(BulletEntity obj)
	{
		Singleton<EntitySystem>.Instance.DeSpawn<BulletEntity>(obj);
		BulletPool.BulletEntityPool.Put(obj);
	}

	// Token: 0x17002052 RID: 8274
	// (get) Token: 0x06017D32 RID: 97586 RVA: 0x006A527C File Offset: 0x006A347C
	public static Pool<BulletHitActorData> BulletHitActorDataPool
	{
		get
		{
			return BulletPool._bulletHitActorDataPool;
		}
	}

	// Token: 0x06017D33 RID: 97587 RVA: 0x006A5284 File Offset: 0x006A3484
	public static BulletHitActorData CreateBulletHitActorData()
	{
		BulletHitActorData bulletHitActorData = BulletPool.BulletHitActorDataPool.Get();
		if (bulletHitActorData == null)
		{
			bulletHitActorData = BulletPool.BulletHitActorDataPool.Create();
		}
		return bulletHitActorData;
	}

	// Token: 0x06017D34 RID: 97588 RVA: 0x006A52AB File Offset: 0x006A34AB
	public static void RecycleBulletHitActorData(BulletHitActorData obj)
	{
		obj.Clear();
		BulletPool.BulletHitActorDataPool.Put(obj);
	}

	// Token: 0x17002053 RID: 8275
	// (get) Token: 0x06017D35 RID: 97589 RVA: 0x006A52BF File Offset: 0x006A34BF
	public static Pool<BulletConditionResult> BulletConditionResultPool
	{
		get
		{
			return BulletPool._bulletConditionResultPool;
		}
	}

	// Token: 0x06017D36 RID: 97590 RVA: 0x006A52C8 File Offset: 0x006A34C8
	public static BulletConditionResult CreateBulletConditionResult()
	{
		BulletConditionResult bulletConditionResult = BulletPool.BulletConditionResultPool.Get();
		if (bulletConditionResult == null)
		{
			bulletConditionResult = BulletPool.BulletConditionResultPool.Create();
		}
		return bulletConditionResult;
	}

	// Token: 0x06017D37 RID: 97591 RVA: 0x006A52EF File Offset: 0x006A34EF
	public static void RecycleBulletConditionResult(BulletConditionResult obj)
	{
		obj.Clear();
		BulletPool.BulletConditionResultPool.Put(obj);
	}

	// Token: 0x17002054 RID: 8276
	// (get) Token: 0x06017D38 RID: 97592 RVA: 0x006A5303 File Offset: 0x006A3503
	public static SimplePool<Vector> VectorPool
	{
		get
		{
			return BulletPool._vectorPool;
		}
	}

	// Token: 0x06017D39 RID: 97593 RVA: 0x006A530C File Offset: 0x006A350C
	public static Vector CreateVector(bool needReset = false)
	{
		Vector vector = BulletPool.VectorPool.Get();
		if (vector == null)
		{
			vector = Vector.Create();
		}
		else if (needReset)
		{
			vector.Reset();
		}
		BulletPool.VectorCount++;
		return vector;
	}

	// Token: 0x06017D3A RID: 97594 RVA: 0x006A5348 File Offset: 0x006A3548
	public static void RecycleVector(Vector obj)
	{
		BulletPool.VectorCount--;
		if (Singleton<BulletConstant>.Instance.OpenPoolCheck)
		{
			obj.Set(double.NaN, double.NaN, double.NaN);
			return;
		}
		BulletPool.VectorPool.Release(obj);
	}

	// Token: 0x17002055 RID: 8277
	// (get) Token: 0x06017D3B RID: 97595 RVA: 0x006A539A File Offset: 0x006A359A
	public static SimplePool<Rotator> RotatorPool
	{
		get
		{
			return BulletPool._rotatorPool;
		}
	}

	// Token: 0x06017D3C RID: 97596 RVA: 0x006A53A4 File Offset: 0x006A35A4
	public static Rotator CreateRotator(bool needReset = false)
	{
		Rotator rotator = BulletPool.RotatorPool.Get();
		if (rotator == null)
		{
			rotator = Rotator.Create();
		}
		else if (needReset)
		{
			rotator.Reset();
		}
		BulletPool.RotatorCount++;
		return rotator;
	}

	// Token: 0x06017D3D RID: 97597 RVA: 0x006A53DD File Offset: 0x006A35DD
	public static void RecycleRotator(Rotator obj)
	{
		BulletPool.RotatorCount--;
		if (Singleton<BulletConstant>.Instance.OpenPoolCheck)
		{
			obj.Set(float.NaN, float.NaN, float.NaN);
			return;
		}
		BulletPool.RotatorPool.Release(obj);
	}

	// Token: 0x17002056 RID: 8278
	// (get) Token: 0x06017D3E RID: 97598 RVA: 0x006A5418 File Offset: 0x006A3618
	public static SimplePool<BulletHitTempResult> BulletHitTempResultPool
	{
		get
		{
			return BulletPool._bulletHitTempResultPool;
		}
	}

	// Token: 0x06017D3F RID: 97599 RVA: 0x006A5420 File Offset: 0x006A3620
	public static BulletHitTempResult CreateBulletHitTempResult()
	{
		BulletHitTempResult bulletHitTempResult = BulletPool.BulletHitTempResultPool.Get();
		if (bulletHitTempResult == null)
		{
			bulletHitTempResult = new BulletHitTempResult();
		}
		BulletPool.BulletHitTempResultCount++;
		return bulletHitTempResult;
	}

	// Token: 0x06017D40 RID: 97600 RVA: 0x006A544E File Offset: 0x006A364E
	public static void RecycleBulletHitTempResult(BulletHitTempResult obj)
	{
		BulletPool.BulletHitTempResultCount--;
		BulletPool.BulletHitTempResultPool.Release(obj);
	}

	// Token: 0x06017D41 RID: 97601 RVA: 0x006A5468 File Offset: 0x006A3668
	public static void CheckAtFrameEnd()
	{
		if (BulletPool.VectorCount != 0)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Bullet;
			ELogAuthor author = ELogAuthor.CFT;
			string message = "当前帧子弹申请的Vector没有回收";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("VectorCount", BulletPool.VectorCount);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			BulletPool.VectorCount = 0;
		}
		if (BulletPool.RotatorCount != 0)
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.Bullet;
			ELogAuthor author2 = ELogAuthor.CFT;
			string message2 = "当前帧子弹申请的Rotator没有回收";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("RotatorCount", BulletPool.RotatorCount);
			instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			BulletPool.RotatorCount = 0;
		}
		if (BulletPool.BulletHitTempResultCount != 0)
		{
			Log instance3 = Singleton<Log>.Instance;
			ELogModule module3 = ELogModule.Bullet;
			ELogAuthor author3 = ELogAuthor.CFT;
			string message3 = "当前帧子弹申请的BulletHitTempResultCount没有回收";
			ValueTuple<string, object> valueTuple3 = new ValueTuple<string, object>("BulletHitTempResultCount", BulletPool.BulletHitTempResultCount);
			instance3.Error(module3, author3, message3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple3));
			BulletPool.BulletHitTempResultCount = 0;
		}
	}

	// Token: 0x06017D42 RID: 97602 RVA: 0x006A552C File Offset: 0x006A372C
	public static void CreateStaticDefaultValue()
	{
		BulletPool._bulletEntityPool = new Lru<string, BulletEntity>(10, (string key) => Singleton<EntitySystem>.Instance.Create<BulletEntity>(0, null), null);
		BulletPool._bulletHitActorDataPool = new Pool<BulletHitActorData>(20, () => new BulletHitActorData(), null);
		BulletPool._bulletConditionResultPool = new Pool<BulletConditionResult>(20, () => new BulletConditionResult(), null);
		BulletPool._vectorPool = new SimplePool<Vector>();
		BulletPool.VectorCount = 0;
		BulletPool._rotatorPool = new SimplePool<Rotator>();
		BulletPool.RotatorCount = 0;
		BulletPool._bulletHitTempResultPool = new SimplePool<BulletHitTempResult>();
		BulletPool.BulletHitTempResultCount = 0;
	}

	// Token: 0x06017D43 RID: 97603 RVA: 0x006A55ED File Offset: 0x006A37ED
	public static void ResetStaticDefaultValue()
	{
		BulletPool._bulletEntityPool = null;
		BulletPool._bulletHitActorDataPool = null;
		BulletPool._bulletConditionResultPool = null;
		BulletPool._vectorPool = null;
		BulletPool.VectorCount = 0;
		BulletPool._rotatorPool = null;
		BulletPool.RotatorCount = 0;
		BulletPool._bulletHitTempResultPool = null;
		BulletPool.BulletHitTempResultCount = 0;
	}

	// Token: 0x0400B8DD RID: 47325
	private const string KEY_BULLET_ENTITY = "bulletEntity";

	// Token: 0x0400B8DE RID: 47326
	private const int PRE_ADD_COUNT = 10;

	// Token: 0x0400B8DF RID: 47327
	private const int CAPACITY = 20;

	// Token: 0x0400B8E0 RID: 47328
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private static Lru<string, BulletEntity> _bulletEntityPool;

	// Token: 0x0400B8E1 RID: 47329
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private static Pool<BulletHitActorData> _bulletHitActorDataPool;

	// Token: 0x0400B8E2 RID: 47330
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private static Pool<BulletConditionResult> _bulletConditionResultPool;

	// Token: 0x0400B8E3 RID: 47331
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private static SimplePool<Vector> _vectorPool;

	// Token: 0x0400B8E4 RID: 47332
	private static int VectorCount;

	// Token: 0x0400B8E5 RID: 47333
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private static SimplePool<Rotator> _rotatorPool;

	// Token: 0x0400B8E6 RID: 47334
	private static int RotatorCount;

	// Token: 0x0400B8E7 RID: 47335
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private static SimplePool<BulletHitTempResult> _bulletHitTempResultPool;

	// Token: 0x0400B8E8 RID: 47336
	private static int BulletHitTempResultCount;
}
