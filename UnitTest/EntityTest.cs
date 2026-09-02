using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;

namespace CSharpScript.UnitTest
{
	// Token: 0x0200444E RID: 17486
	[NullableContext(1)]
	[Nullable(0)]
	[UnitTest]
	public class EntityTest : UnitTestBase
	{
		// Token: 0x17007FB3 RID: 32691
		// (get) Token: 0x0602E3A6 RID: 189350 RVA: 0x00ADC2BF File Offset: 0x00ADA4BF
		public override string Name
		{
			get
			{
				return "EntityTest";
			}
		}

		// Token: 0x0602E3A7 RID: 189351 RVA: 0x00ADC2C8 File Offset: 0x00ADA4C8
		[NullableContext(0)]
		public override UniTask<bool> Run([Nullable(1)] params object[] args)
		{
			int num = 0;
			EntityTest.TestEntity testEntity = Singleton<EntitySystem>.Instance.Create<EntityTest.TestEntity>(0, new EntityArgs<int>(10));
			this._Entities.Add(num + 1, testEntity);
			Singleton<EntitySystem>.Instance.InitData<EntityTest.TestEntity>(testEntity, new EntityArgs<int>(10));
			Singleton<EntitySystem>.Instance.Init(testEntity);
			Singleton<EntitySystem>.Instance.Start(testEntity);
			Singleton<EntitySystem>.Instance.Activate(testEntity);
			EntityTest.Component1 component = testEntity.GetComponent<EntityTest.Component1>();
			component.B = 5.2f;
			component.C = "efg";
			EntityTest.Component2 component2 = testEntity.GetComponent<EntityTest.Component2>();
			base.Info(component.Content, default(ReadOnlySpan<ValueTuple<string, object>>));
			base.Info(component2.Content, default(ReadOnlySpan<ValueTuple<string, object>>));
			Singleton<EntitySystem>.Instance.Tick(0.1f);
			Singleton<EntitySystem>.Instance.Destroy<EntityTest.TestEntity>(testEntity);
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(39, 1);
			defaultInterpolatedStringHandler.AppendLiteral("Component1的B还原回默认值0.1f  component1.B = ");
			defaultInterpolatedStringHandler.AppendFormatted<float>(component.B);
			base.Info(defaultInterpolatedStringHandler.ToStringAndClear(), default(ReadOnlySpan<ValueTuple<string, object>>));
			base.Info("Component1的C还原回默认值abc component1.C = " + component.C, default(ReadOnlySpan<ValueTuple<string, object>>));
			return UniTask.FromResult<bool>(true);
		}

		// Token: 0x0401A409 RID: 107529
		private readonly Dictionary<int, EntityTest.TestEntity> _Entities = new Dictionary<int, EntityTest.TestEntity>();

		// Token: 0x0200A65D RID: 42589
		[Nullable(0)]
		public class Component1 : EntityComponent
		{
			// Token: 0x1700A905 RID: 43269
			// (get) Token: 0x0604A611 RID: 304657 RVA: 0x01431C4E File Offset: 0x0142FE4E
			public string Content
			{
				get
				{
					return "这是Component1的内容";
				}
			}

			// Token: 0x0604A612 RID: 304658 RVA: 0x01431C58 File Offset: 0x0142FE58
			[NullableContext(2)]
			protected override bool OnCreate(IEntityArgs args = null)
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(25, 1);
				defaultInterpolatedStringHandler.AppendLiteral("执行Component1的OnCreate 参数:");
				defaultInterpolatedStringHandler.AppendFormatted<int>(args.GetP1<int>());
				UnitTestSystem.Info(defaultInterpolatedStringHandler.ToStringAndClear(), default(ReadOnlySpan<ValueTuple<string, object>>));
				return true;
			}

			// Token: 0x0604A613 RID: 304659 RVA: 0x01431CA0 File Offset: 0x0142FEA0
			[NullableContext(2)]
			protected override bool OnInitData(IEntityArgs args = null)
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(27, 1);
				defaultInterpolatedStringHandler.AppendLiteral("执行Component1的OnInitData 参数:");
				defaultInterpolatedStringHandler.AppendFormatted<int>(args.GetP1<int>());
				UnitTestSystem.Info(defaultInterpolatedStringHandler.ToStringAndClear(), default(ReadOnlySpan<ValueTuple<string, object>>));
				return true;
			}

			// Token: 0x0604A614 RID: 304660 RVA: 0x01431CE8 File Offset: 0x0142FEE8
			protected override bool OnInit()
			{
				UnitTestSystem.Info("执行Component1的OnInit", default(ReadOnlySpan<ValueTuple<string, object>>));
				return true;
			}

			// Token: 0x0604A615 RID: 304661 RVA: 0x01431D0C File Offset: 0x0142FF0C
			protected override bool OnStart()
			{
				UnitTestSystem.Info("执行Component1的OnStart", default(ReadOnlySpan<ValueTuple<string, object>>));
				return true;
			}

			// Token: 0x0604A616 RID: 304662 RVA: 0x01431D30 File Offset: 0x0142FF30
			protected override void OnActivate()
			{
				UnitTestSystem.Info("执行Component1的OnActivate", default(ReadOnlySpan<ValueTuple<string, object>>));
			}

			// Token: 0x0604A617 RID: 304663 RVA: 0x01431D50 File Offset: 0x0142FF50
			protected override void OnTick(float delta)
			{
				UnitTestSystem.Info("执行Component1的OnTick", default(ReadOnlySpan<ValueTuple<string, object>>));
			}

			// Token: 0x0604A618 RID: 304664 RVA: 0x01431D70 File Offset: 0x0142FF70
			protected override bool OnEnd()
			{
				UnitTestSystem.Info("执行Component1的OnEnd", default(ReadOnlySpan<ValueTuple<string, object>>));
				return true;
			}

			// Token: 0x0604A619 RID: 304665 RVA: 0x01431D94 File Offset: 0x0142FF94
			protected override bool OnClear()
			{
				UnitTestSystem.Info("执行Component1的OnClear", default(ReadOnlySpan<ValueTuple<string, object>>));
				return true;
			}

			// Token: 0x0403370B RID: 210699
			public float B = 0.1f;

			// Token: 0x0403370C RID: 210700
			public string C = "abc";
		}

		// Token: 0x0200A65E RID: 42590
		[Nullable(0)]
		public class Component2 : EntityComponent, IComponentDependency
		{
			// Token: 0x1700A906 RID: 43270
			// (get) Token: 0x0604A61B RID: 304667 RVA: 0x01431DD3 File Offset: 0x0142FFD3
			public string Content
			{
				get
				{
					return "这是Component2的内容";
				}
			}

			// Token: 0x1700A907 RID: 43271
			// (get) Token: 0x0604A61C RID: 304668 RVA: 0x01431DDA File Offset: 0x0142FFDA
			public static Type[] Dependencies
			{
				get
				{
					return new Type[]
					{
						typeof(EntityTest.Component1)
					};
				}
			}

			// Token: 0x0604A61D RID: 304669 RVA: 0x01431DF0 File Offset: 0x0142FFF0
			[NullableContext(2)]
			protected override bool OnCreate(IEntityArgs args = null)
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(25, 1);
				defaultInterpolatedStringHandler.AppendLiteral("执行Component2的OnCreate 参数:");
				defaultInterpolatedStringHandler.AppendFormatted<int>(args.GetP1<int>());
				UnitTestSystem.Info(defaultInterpolatedStringHandler.ToStringAndClear(), default(ReadOnlySpan<ValueTuple<string, object>>));
				return true;
			}

			// Token: 0x0604A61E RID: 304670 RVA: 0x01431E38 File Offset: 0x01430038
			[NullableContext(2)]
			protected override bool OnInitData(IEntityArgs args = null)
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(27, 1);
				defaultInterpolatedStringHandler.AppendLiteral("执行Component2的OnInitData 参数:");
				defaultInterpolatedStringHandler.AppendFormatted<int>(args.GetP1<int>());
				UnitTestSystem.Info(defaultInterpolatedStringHandler.ToStringAndClear(), default(ReadOnlySpan<ValueTuple<string, object>>));
				return true;
			}

			// Token: 0x0604A61F RID: 304671 RVA: 0x01431E80 File Offset: 0x01430080
			protected override bool OnInit()
			{
				UnitTestSystem.Info("执行Component2的OnInit", default(ReadOnlySpan<ValueTuple<string, object>>));
				return true;
			}

			// Token: 0x0604A620 RID: 304672 RVA: 0x01431EA4 File Offset: 0x014300A4
			protected override bool OnStart()
			{
				UnitTestSystem.Info("执行Component2的OnStart", default(ReadOnlySpan<ValueTuple<string, object>>));
				return true;
			}

			// Token: 0x0604A621 RID: 304673 RVA: 0x01431EC8 File Offset: 0x014300C8
			protected override void OnActivate()
			{
				UnitTestSystem.Info("执行Component2的OnActivate", default(ReadOnlySpan<ValueTuple<string, object>>));
			}

			// Token: 0x0604A622 RID: 304674 RVA: 0x01431EE8 File Offset: 0x014300E8
			protected override bool OnEnd()
			{
				UnitTestSystem.Info("执行Component2的OnEnd", default(ReadOnlySpan<ValueTuple<string, object>>));
				return true;
			}

			// Token: 0x0604A623 RID: 304675 RVA: 0x01431F0C File Offset: 0x0143010C
			protected override bool OnClear()
			{
				UnitTestSystem.Info("执行Component2的OnClear", default(ReadOnlySpan<ValueTuple<string, object>>));
				return true;
			}
		}

		// Token: 0x0200A65F RID: 42591
		[NullableContext(0)]
		public class TestEntity : Entity
		{
			// Token: 0x1700A908 RID: 43272
			// (get) Token: 0x0604A625 RID: 304677 RVA: 0x01431F35 File Offset: 0x01430135
			public override bool UsePool
			{
				get
				{
					return true;
				}
			}

			// Token: 0x0604A626 RID: 304678 RVA: 0x01431F38 File Offset: 0x01430138
			public TestEntity(int id, int index) : base(id, index)
			{
			}

			// Token: 0x0604A627 RID: 304679 RVA: 0x01431F50 File Offset: 0x01430150
			[NullableContext(2)]
			protected override bool OnCreate(IEntityArgs args = null)
			{
				int p = args.GetP1<int>();
				EntityArgs<int> entityArgs = new EntityArgs<int>(p);
				base.AddComponent<EntityTest.Component1>(new int?(1), entityArgs);
				base.AddComponent<EntityTest.Component2>(null, entityArgs);
				return true;
			}

			// Token: 0x0403370D RID: 210701
			[Nullable(1)]
			private Dictionary<int, string> content = new Dictionary<int, string>();
		}
	}
}
