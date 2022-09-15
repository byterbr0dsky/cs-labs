.assembly MyCoolShit
{
    .ver 1:0:0:0
}
.module MyCoolShit.exe

.namespace Program
{
    .class public auto sealed MyCoolShit extends [mscorlib]System.Object
    {
        .field public int32 gg
        .method public hidebysig instance void .ctor(int32 g) cil managed
        {
            .maxstack 8
            ldarg.0
            call instance void [mscorlib]System.Object::.ctor()
            ldarg.0
            ldarg.1
            stfld int32 Program.MyCoolShit::gg
            ret
        }
    }

    .class public auto ansi sealed beforefieldinit AAA
       extends [mscorlib]System.Object
    {
        .method public hidebysig static void Main() cil managed
        {
            .entrypoint
            .maxstack 8
            .locals init ([0] class Program.MyCoolShit shit)

            ldc.i4 25
            newobj instance void Program.MyCoolShit::.ctor(int32)
            stloc.0
            ldloc.0
            ldfld int32 Program.MyCoolShit::gg
            box [mscorlib]System.Int32
            callvirt instance [mscorlib]System.Type [mscorlib]System.Object::GetType()
            callvirt instance string [mscorlib]System.Object::ToString()
            
            call void [mscorlib]System.Console::WriteLine(string)
            ret
        }
    }
}
