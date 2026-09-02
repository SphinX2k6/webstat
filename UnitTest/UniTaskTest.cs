using System;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;

namespace CSharpScript.UnitTest
{
	// Token: 0x02004464 RID: 17508
	[UnitTest]
	public class UniTaskTest : UnitTestBase
	{
		// Token: 0x17007FBA RID: 32698
		// (get) Token: 0x0602E3FE RID: 189438 RVA: 0x00ADCDE6 File Offset: 0x00ADAFE6
		[Nullable(1)]
		public override string Name
		{
			[NullableContext(1)]
			get
			{
				return "UniTaskTest";
			}
		}

		// Token: 0x0602E3FF RID: 189439 RVA: 0x00ADCDED File Offset: 0x00ADAFED
		public override UniTask<bool> Run([Nullable(1)] params object[] args)
		{
			throw new NotImplementedException();
		}
	}
}
