using CarRental.Domain.CouponModule;
using CarRental.Domain.VehicleGroupModule;
using CarRental.Domain.ServiceModule;
using System;
using System.Collections.Generic;

namespace CarRental.Domain.Shared
{
    public static class CalculateRental
    {
        public const double VALOR_SEGURO_CLIENTE = 250.50f;
        public const double VALOR_SEGURO_TERCEIRO = 500.75f;
        public const double VALOR_GARANTIA = 1000f;
        public const double PORCENT_MULTA_DE_ATRASO_DIARIA = 0.1f;

        public static double CalculateGuarantee()
        {
            return VALOR_GARANTIA;
        }

        public static double CalculateInsurance(string insuranceType)
        {
            double valorFinal;
            if (insuranceType.Equals("SeguroCliente"))
                    valorFinal = VALOR_SEGURO_CLIENTE;
            else if(insuranceType.Equals("SeguroTerceiro"))
                valorFinal = VALOR_SEGURO_TERCEIRO;
            else
                valorFinal = 0;
            return valorFinal;
        }

        public static double CalculatePlan(string tipoPlano, VehicleGroup grupoDeVeiculos, double kilometragemRodada, DateTime dataInicial, DateTime dataFinal) 
        {
            double intervaloDeDias = (dataFinal - dataInicial).TotalDays;
            double precoPorDia = 0;
            double precoPorKm = 0;
            switch (tipoPlano)
            {
                case "PlanoDiario":     //calculado por dia e por km rodado.
                    precoPorDia = grupoDeVeiculos.DailyPlanRate * intervaloDeDias;
                    precoPorKm = kilometragemRodada * grupoDeVeiculos.DailyPerKmRate;
                    break;

                case "KmControlado":    // pago por dia e com uma quantidade que pode rodar por dia. Caso extrapole paga a mais por km.
                    precoPorDia = grupoDeVeiculos.ControlledPlanRate * intervaloDeDias;
                    if (intervaloDeDias > grupoDeVeiculos.ControlledKmLimit)
                        precoPorKm = (kilometragemRodada - grupoDeVeiculos.ControlledKmLimit) * grupoDeVeiculos.ControlledExceededKmRate;
                    break;

                case "KmLivre":         //paga apenas a diária e sem controle de km.
                    precoPorDia = grupoDeVeiculos.UnlimitedPlanRate * intervaloDeDias;
                    break;
            }
            return precoPorDia + precoPorKm;
        }

        public static double CalculateServices(List<Service> servicos, DateTime dataInicial, DateTime dataFinal)
        {
            double resultado = 0;
            double intervaloDeDias = (dataFinal - dataInicial).TotalDays;
            foreach (Service servico in servicos)
            {
                if (servico.IsChargedDaily)
                    resultado += servico.Value * intervaloDeDias;
                else
                    resultado += servico.Value;
            }
            return resultado;
        }

        public static double CalculateFuelDifference(double qtdTotalTanque, double porcentCombustivelAtual, double valorPorLitro)
        {
            double medidaAtualDoTanque = qtdTotalTanque * porcentCombustivelAtual;
            double diferencaDoTanque = qtdTotalTanque - medidaAtualDoTanque;
            double valorAPagar = diferencaDoTanque * valorPorLitro;

            return valorAPagar;
        }

        public static double CalculateLateReturnFee(double precoTotal, DateTime dataPrevistaDeChegada, DateTime dataRealDeChegada)
        {
            double resultado = 0;
            if (dataRealDeChegada > dataPrevistaDeChegada) 
            {
                double diferencaDeDias = (dataRealDeChegada - dataPrevistaDeChegada).TotalDays;
                double fracaoDoPrecoTotal = precoTotal * PORCENT_MULTA_DE_ATRASO_DIARIA;
                resultado = fracaoDoPrecoTotal * diferencaDeDias;
            }
            return resultado;
        }

        public static double CalculateDiscountCoupon(double precoTotal, CouponModule.Coupon cupom)
        {
            double resultado = 0;
            if (cupom != null)
            {
                bool ehAindaValidoHoje = DateTime.Now <= cupom.ExpirationDate;
                bool ehValorMaiorQuePrecoMinimo = precoTotal >= cupom.MinimumValue;

                if (ehAindaValidoHoje && ehValorMaiorQuePrecoMinimo)
                {
                    if (cupom.IsFixedDiscount)
                        resultado = cupom.Value;
                    else
                    {
                        double porcentagemDeDesconto = cupom.Value / 100;
                        resultado = precoTotal * porcentagemDeDesconto;
                    }
                }
            }
            return resultado;
        }
    }
}
